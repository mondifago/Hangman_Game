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

        const int MAX_NUM_OF_TRIES = 6;
        string correctlyGuessedChar = "";
        Random rng = new Random();
        int randomIndex = rng.Next(0, wordPool.Count);
        string selectedWord = wordPool[randomIndex];
       
        Console.WriteLine("-----------------------------------Welcome to Hangmans Game----------------------------------------\n");
        Console.WriteLine("One of Melbourne's suburbs has been picked at random. you are to guess an alphabet that is part");
        Console.WriteLine("of the spelling of this suburb one after the other until you completely spell the surburb.");
        Console.WriteLine($"In the case of a wrong guess, you have {MAX_NUM_OF_TRIES} retries, after which you loose the game.");

        for (int i = 0; i <= selectedWord.Length+2; i++)
        {
            if (correctlyGuessedChar.Length == selectedWord.Length)
            {
                Console.WriteLine("Congratulations! You've guessed all characters.");
                Console.WriteLine($"The full word is: {selectedWord}");
                break;
            }

            Console.WriteLine("Guess your alphabet: \n");
            char userInput = Console.ReadLine()[0];
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
                correctlyGuessedChar += userInput;
            }

            if (!selectedWord.Contains(userInput))
            {
                foreach (char c in selectedWord)
                {
                    Console.Write(hiddenChar + " ");
                }

                Console.WriteLine("\n");

                if (i < MAX_NUM_OF_TRIES - 1)
                {
                    Console.WriteLine($"You have {MAX_NUM_OF_TRIES - (i + 1)} tries left.");
                }
                else
                {
                    Console.WriteLine("Maximum number of tries reached. GAME OVER!");
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}

