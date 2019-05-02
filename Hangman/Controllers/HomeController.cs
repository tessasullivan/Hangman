using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HangmanGame.Models;

namespace ProjectName.Controllers
{
  public class HomeController : Controller
  {
    private static Hangman hangman = new Hangman();
    

    [HttpGet("/")]
    public ActionResult Index() 
    {        
      return View("Index", hangman); 
    }

    [HttpPost("/guess")]
    public ActionResult Create(char guess)
    {
      hangman.CheckGuess(guess);
      if(hangman.GetHasWon())
      {
        return RedirectToAction("Win");
      }
      if(hangman.GetLives() >= 6)
      {
        return RedirectToAction("Lose");
      }

      return RedirectToAction("Index");
    }

    [HttpGet("/lose")]
    public ActionResult Lose()
    {
      string word = hangman.Word;
      hangman = new Hangman();
      return View(word);
    }

    [HttpGet("/win")]
    public ActionResult Win()
    {
      hangman = new Hangman();
      return View();
    }

  }
}
