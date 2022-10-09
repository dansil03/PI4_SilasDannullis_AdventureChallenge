using AdventureChallenge.Data;
using AdventureChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AdventureChallenge.Controllers
{
    public class UserChallengeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public bool Exists; 
        public Challenge challenge; 
        private readonly AppDbContext _context;
        public UserChallengeController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult FindChallenge()
        {
            return View(); 
        }
        public IActionResult StartChallenge(Challenge FoundChallenge)
        {
            List<Challenge> FoundChallenges = new List<Challenge>();
            foreach(Challenge challenge in _context.challenges
                .Where(c => c.NumberOfPlayers == FoundChallenge.NumberOfPlayers && c.DayTime == FoundChallenge.DayTime))
            {
                FoundChallenges.Add(challenge);
            }
            ViewBag.challenges = FoundChallenges;

            return View();
        }


        public IActionResult GetChallenge(int id)
        {
            challenge = _context.challenges.Find(id);
            HttpContext.Session.SetString("ChallengeSession", JsonConvert.SerializeObject(challenge));
            return RedirectToAction("SaveChallenge", "UserChallenge", new {id = id});
        }

        public IActionResult SaveChallenge(int id)
        {
            var challenge = _context.challenges.Find(id);
            return View(challenge); 
        }

        [HttpPost]
        public IActionResult AddChallengeToUserChallenge(UserChallenge userChallenge)
        {
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
            userChallenge.UserId = user.id; 
            Challenge challenge = JsonConvert.DeserializeObject<Challenge>(HttpContext.Session.GetString("ChallengeSession"));
            userChallenge.ChallengeId = challenge.Id;

            foreach (UserChallenge uc in _context.userChallenges
                .Where(uc => uc.UserId == userChallenge.UserId))
            {
                if(uc.ChallengeId == userChallenge.ChallengeId)
                {
                    Exists = true;
                }
            } 

            if (Exists == false)
            {
                _context.userChallenges.Add(userChallenge);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Challenge");
        }

        [HttpGet]
        public async Task<IActionResult> FinishedChallenges()
        {
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
            var ChallengeUser = await _context.Users
                .Include(x => x.UserChallenges.Where(s => s.Status == true))
                .ThenInclude(y => y.Challenge)
                .SingleOrDefaultAsync(m => m.id == user.id);

            return View(ChallengeUser); 
        }

        public IActionResult ChallengeOverView(int id)
        {
            var userchallenge = _context.userChallenges.Find(id);
            return View(userchallenge); 
        }

        [HttpGet]
        public async Task<IActionResult> ChooseActiveChallenge()
        {
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
         
            var ChallengeUser = await _context.Users
                .Include(x => x.UserChallenges.Where(s => s.Status == false))
                .ThenInclude(y => y.Challenge)
                .SingleOrDefaultAsync(m => m.id == user.id);

            return View(ChallengeUser); 
        }
        public IActionResult FinishChallenge(int id)
        {
            var userchallenge = _context.userChallenges.Find(id);    
            return View(userchallenge); 
        }
        private string UploadedFile(UserChallenge userChallenge)
        {
            string uniqueFileName = null;

            if (userChallenge.ProofImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProofImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + userChallenge.ProofImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    userChallenge.ProofImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]
        public async Task<IActionResult> AddProof(int id, UserChallenge userChallenge)
        {
            //[Bind("UserChallengeId, ChallengeId, UserId, ProofText", "ImgUrl")]
            string uniqueFileName = UploadedFile(userChallenge);
            userChallenge.ImgUrl = uniqueFileName;

            if(userChallenge.ProofText != null)
            {
                userChallenge.Status = true; 
            }

            _context.Update(userChallenge); 
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Challenge"); 
        }
    }
}