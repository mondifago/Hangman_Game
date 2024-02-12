using System;
using System.Collections.Generic;

namespace Hangman_Game;

class Program
{
    static void Main(string[] args)
    {
        List<string> wordPool = new List<string>();

        wordPool.Add("Brunswick");
        wordPool.Add("Wyndham");
        wordPool.Add("Boxhill");
        wordPool.Add("Werribee");
        wordPool.Add("Hoppers crossing");
        wordPool.Add("Piont cook");
        wordPool.Add("Preston");
        wordPool.Add("Sunshine");
        wordPool.Add("St Albans");
        wordPool.Add("Melbourne CBD");
        wordPool.Add("Footstray");
        wordPool.Add("St Kilda");
        wordPool.Add("Epping");
        wordPool.Add("Heidelberg");
        wordPool.Add("Richmond");
        wordPool.Add("Fraser Rise");
        wordPool.Add("Camberwell");
        wordPool.Add("Melton");
        wordPool.Add("Bacchus Marsh");
        wordPool.Add("Geelong");

        Random rng = new Random();
        int randomIndex = rng.Next(0, wordPool.Count);
        string selectedWord = wordPool[randomIndex];

        Console.WriteLine(selectedWord);
    }
}

