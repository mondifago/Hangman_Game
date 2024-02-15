using System;
using System.Collections.Generic;

namespace Hangman_Game;

class Program
{
    static void Main(string[] args)
    {
        List<string> wordPool = new List<string>()
        {
            "brunswick",
            "wyndham",
            "boxhill",
            "werribee",
            "hoppers crossing",
            "piont cook",
            "preston",
            "sunshine",
            "st albans",
            "melbourne cbd",
            "footstray",
            "st kilda",
            "epping",
            "heidelberg",
            "richmond",
            "fraser Rise",
            "camberwell",
            "melton",
            "bacchus marsh",
            "geelong"
        };


        Random rng = new Random();
        int randomIndex = rng.Next(0, wordPool.Count);
        string selectedWord = wordPool[randomIndex];

        Console.WriteLine("-----------------------------------This is Hangmans Game----------------------------------------\n");
        Console.WriteLine("One of Melbourne's suburbs has been picked at random. you are to guess an alphabet that is part");
        Console.WriteLine("of the spelling of this suburb one after the other until you completely spell the surburb.");
        Console.WriteLine("In the case of a wrong guess, you have 6 retries, after which you loose the game.");


        Console.WriteLine("Guess your alphabet: \n");
        char userInput = Convert.ToChar (Console.ReadLine());
        Console.WriteLine("\n");
        char hiddenChar = '_';


        if (selectedWord.Contains(userInput))
        {
            foreach (char c in selectedWord)
            {
                if (c == userInput)
                {
                    Console.Write(c + " ");
                }
                else
                {
                    Console.Write(hiddenChar + " ");
                }
                
            }

        }
        else
            foreach (char c in selectedWord)
            {
                Console.Write(hiddenChar + " ");
            }


    }
}

