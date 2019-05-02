using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HangmanGame.Models;

namespace ProjectName.Controllers
{
  public class HomeController : Controller
  {
    Hangman hangman = new Hangman();

    [HttpGet("/")]
    public ActionResult Index() 
    {        
      return View("Index", hangman); 
    }

    [HttpPost("/guess")]
    public ActionResult Create(char guess)
    {
      hangman.CheckGuess(guess);
      return RedirectToAction("Index");
    }
  }
}
