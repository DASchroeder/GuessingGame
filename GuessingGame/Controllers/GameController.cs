using GuessingGame.Models;
using GuessingGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessingGame.Controllers
{
    public class GameController : Controller
    {
        private readonly IRandomNumberGenerator _rng;


        public GameController(IRandomNumberGenerator rng)
        {
            _rng = rng;  //TODO why is it underscore rng ? A: naming convention to indicate its part of the private class
        }

        public ActionResult Index()
        {
            IRandomNumberGenerator rng = new AdvancedRandomNumberGenerator();
            Session["Answer"] = rng.GetNext(1, 10);  //Random number generator, find a better one for a challenge

            return View();
        }

        private bool GuessWasCorrect(int guess) =>
            guess == (int)Session["Answer"];  //(int) is a cast, to tell the compiler it is an int 


        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Index(GameModel model) //OVERLOAD
        {
            if (ModelState.IsValid)
            {
                ViewBag.Win = GuessWasCorrect(model.Guess);
            }
            

            return View(model);
        }
    }
}