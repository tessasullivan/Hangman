using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HangmanGame.Models
{
  public class Hangman
  {
    private string _word;
    public string Word
    {
      get { return _word; }
    }
    private string[] _words = new string[] {"watermelon", "pizza", "chips", "coke", "cookie", "chocolate", "apple", "banananananana"};
    private int _lives = 0;
    private bool _hasWon = false;
    private char[] _splitWord;
    private List<char> uniqueChars = new List<char>{};
    private List<char> guesses = new List<char>{};
    private List<char> misses = new List<char>{};
    public string pic;
    private string[] pics = new string[] 
    {"hangman0.png", "hangman1.png", "hangman2.png", "hangman3.png", "hangman4.png", "hangman5.png", "hangman6.png"};

    public Hangman()
    {
      SetWord();
      FillCharList();
      SetPic();

    }
    public bool GetHasWon()
    {
      return _hasWon;
    }
    public void SetPic()
    {
      pic = pics[_lives];
    }


    public void FillCharList()
    {
      foreach(char letter in _word)
      {
        if(!uniqueChars.Contains(letter))
        {
          uniqueChars.Add(letter);
        }
      }
    }

    public void CheckGuess(char guess)
    {
      guesses.Add(guess);

      if(uniqueChars.Contains(guess))
      {
        uniqueChars.Remove(guess);
      }
      else
      {
        misses.Add(guess);
        SetLives();
        SetPic();
      }
      if(uniqueChars.Count < 1)
      {
        _hasWon = true;
        // Console.WriteLine("winner");
      }
    }
    public int GetLives()
    {
      return _lives;
    }
    public void SetLives()
    {
      _lives++;
    }

    public void SetWord()
    {
      Random rng = new Random();
      _word = _words[rng.Next(0, _words.Length)];
      _splitWord = new char[_word.Length];
      for(int i = 0; i < _splitWord.Length; i++)
      {
        _splitWord[i]='_';
      }
    }
    public string DrawWord()
    {
      foreach(char guess in guesses)
      {
        for(int i = 0; i < _word.Length; i++)
        {
          if(guess == _word[i])
          {
            _splitWord[i] = guess;
          }
        }
      }
      return String.Join(' ', _splitWord);
    }
    public string DisplayIncorrectGuesses()
    {
      string output = "";
      foreach(char guess in misses)
      {
        output += guess + " ";
      }
      return output;
    }
  }
}