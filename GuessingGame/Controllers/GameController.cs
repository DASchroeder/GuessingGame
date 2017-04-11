using GuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessingGame.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {                 
            Session["Answer"] = new Random().Next(1, 10); //Random number generator, find a better one for a challenge

            return View();
        }

        private bool GuessWasCorrect(int guess) =>
            guess == (int)Session["Answer"];  //(int) is a cast, to tell the compiler it is an int 


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Index(GameModel model) //OVERLOAD
        {
            ViewBag.Win = GuessWasCorrect(model.Guess);

            return View(model);
        }
    }
}