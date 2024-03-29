﻿using System;
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
            "point cook",
            "preston",
            "sunshine",
            "st albans",
            "melbourne cbd",
            "footscray",
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
        const int NUMBER_OF_TRIES_FINISHED = 0;
        const int INITIAL_MAX_NUMBER_OF_TRIES = 6;
        const char SPACE_BTW_WORDS = ' ';
        const char HIDDEN_CHAR = '_';
        int maxNumOfTries = INITIAL_MAX_NUMBER_OF_TRIES;
        Random rng = new Random();
        int randomIndex = rng.Next(0, wordPool.Count);
        string selectedWord = wordPool[randomIndex];
        //selectedWord = "test me"; //FOR TESTING ONLY 
        string correctlyGuessedChar = "";
        char[] updatedCorrectlyGuessed = new char[selectedWord.Length];
        char userInput ;

        Console.WriteLine("-----------------------------------Welcome to Hangmans Game----------------------------------------\n");
        Console.WriteLine("One of Melbourne's suburbs has been picked at random. you are to guess an alphabet that is part");
        Console.WriteLine("of the spelling of this suburb one after the other until you completely spell the surburb.");
        Console.WriteLine($"In the case of a wrong guess, you have {maxNumOfTries} retries, after which you loose the game.\n");

        //todo: before starting the game, update all spaces in updatedCorrectlyGuessed with the actual spaces
        for(int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == SPACE_BTW_WORDS)
                updatedCorrectlyGuessed[i] = SPACE_BTW_WORDS;
        }

        while (maxNumOfTries>NUMBER_OF_TRIES_FINISHED)
        {
            Console.WriteLine($"\n\nGuess your alphabet: \n");

            try
            {
                userInput = Console.ReadLine()[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error: choose a letter before pressing enter key");
                continue;
            }
            if (!char.IsLetter(userInput) && userInput != SPACE_BTW_WORDS) 
            {
                Console.WriteLine("Invalid input. Please enter only letters and space.");
                continue;
            }
            Console.WriteLine("\n");

            if (selectedWord.Contains(userInput))
            {
                Console.WriteLine("CORRECT GUESS!\n");
                bool allGuessed = true;

                for (int i = 0; i < selectedWord.Length; i++)
                {
                    if (userInput == selectedWord[i])
                    {
                        updatedCorrectlyGuessed[i] = userInput;
                    }
                    if (updatedCorrectlyGuessed[i] == HIDDEN_CHAR)
                    {
                        allGuessed = false;
                    }
                }
              
                foreach (char c in selectedWord)
                {
                    bool isGuessed = false;
                    for (int i = 0; i < updatedCorrectlyGuessed.Length; i++)
                    {
                        if (c == updatedCorrectlyGuessed[i])
                        {
                            isGuessed = true;
                            break;
                        }
                    }
                    if (isGuessed)
                    {
                        Console.Write(c + " ");
                    }
                    else
                    {
                        Console.Write(HIDDEN_CHAR + " ");
                    }
                }
                if (allGuessed)
                {
                    correctlyGuessedChar = string.Join("", updatedCorrectlyGuessed);
                }
            }

            if (correctlyGuessedChar == selectedWord)
            {
                Console.WriteLine("\n\nCongratulations! You've guessed all characters.");
                Console.WriteLine($"The full word is: {selectedWord}");
                break;
            }

            if (!selectedWord.Contains(userInput))
            {
                maxNumOfTries--;
                Console.WriteLine("\n");

                if (maxNumOfTries == NUMBER_OF_TRIES_FINISHED)
                {
                    Console.WriteLine("Maximum number of tries reached. GAME OVER!");
                    return;
                }
                if (maxNumOfTries <INITIAL_MAX_NUMBER_OF_TRIES)
                {
                    Console.WriteLine($"WRONG GUESS! You have {maxNumOfTries} tries left.");
                    Console.WriteLine($"Press R to see correctly guessed letters again or press ENTER to contiune");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.R)
                    {
                        Console.Clear();
                        foreach (char c in selectedWord)
                        {
                            bool isGuessed = false;
                            for (int i = 0; i < updatedCorrectlyGuessed.Length; i++)
                            {
                                if (c == updatedCorrectlyGuessed[i])
                                {
                                    isGuessed = true;
                                    break;
                                }
                            }
                            if (isGuessed)
                            {
                                Console.Write(c + " ");
                            }
                            else
                            {
                                Console.Write(HIDDEN_CHAR + " ");
                            }
                        }
                        continue;
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        continue;
                    }
                } 
            }
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

