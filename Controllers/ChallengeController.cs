using AdventureChallenge.Data;
using AdventureChallenge.Migrations;
using AdventureChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AdventureChallenge.Controllers
{
    public class ChallengeController : Controller
    {
        public int LoggedId;
        private readonly AppDbContext appDb;
        public ChallengeController(AppDbContext _appDb)
        {
            appDb = _appDb;
        }

        public IActionResult Index(int id)
        {           
            return View();
        }

        public IActionResult CreateButton()
        {
            return RedirectToAction("CreateChallenge", "Challenge");
        }
        public IActionResult CreateChallenge(int id)
        {
            return View();
        }
        public IActionResult Overzicht()
        {
            var challenges = appDb.challenges.ToList();
            ViewBag.challenges = challenges;
            return View();
        }

        [HttpPost]
        public IActionResult ChallengePost(Challenge challenge)
        {
            appDb.challenges.Add(challenge);
            appDb.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            var challenge = await appDb.challenges
                .FirstOrDefaultAsync(x => x.Id == id);
            if (challenge == null)
            {
                return NotFound(); 
            }

            return View(challenge);

        }
    }
}
