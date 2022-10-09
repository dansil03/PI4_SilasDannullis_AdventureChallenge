using AdventureChallenge.Data;
using AdventureChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace AdventureChallenge.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private User RightUser;
        private bool found;
        public int loggedId; 
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Overzicht()
        {
            var users = _context.Users.ToList();
            ViewBag.users = users;
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginCheck(User user)
        {
            foreach (User user2 in _context.Users)
            {
                if (user2.UserName == user.UserName)
                { 
                    RightUser = user2;
                    found = true;
                    break;
                }
                else
                {
                    found = false;
                }
            }
            if (found == true)
            {
                if (RightUser.Password == user.Password)
                {
                    //set user into session key
                    HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(RightUser));
                    return RedirectToAction("Index", "Challenge");
                }
                else
                { 
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }

            return Ok();
        } 

        public IActionResult SignUp(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpPost(User user)
        {
            if(user.id == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                _context.Users.Update(user);
            }
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }
            return View (user);
        }
    }
}
