using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("### HANGMAN ###");
                Console.WriteLine("###############");
                Console.WriteLine();

                Console.WriteLine("Wähle eine Aktion aus: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Spielen");
                Console.WriteLine("[2] Beenden");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("Aktion: ");
                int action = Convert.ToInt32(Console.ReadLine());
                bool end = false;

                switch (action)
                {
                    case 1:
                        StartGame();
                        break;

                    case 2:
                        end = true;
                        break;
                }
                if (end)
                {
                    break;
                }

                Console.Clear();
            }
        }

        static void StartGame()
        {
            string[] words = new string[]
            {
                "Apfelkuchen",
                "Flasche",
                "Tasche",
                "Haushalt",
                "Sportwagen",
                "Videospiel",
                "Weltraum"
            };

            Random rnd = new Random();
            int index = rnd.Next(0, words.Length);
            string word = words[index].ToLower();
            GameLoop(word);
        }
    
        static void GameLoop(string word)
        {
            int Lives = 10;
            string hiddenWord = "";

            for(int i = 0; i < word.Length; i++)
            {
                hiddenWord += "_";
            }

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Gesuchtes Wort: " + hiddenWord);
                Console.Write("Noch übrige Versuche: ");

                for(int i = 0; i < Lives; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("X");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.Write("Buchstabe: ");
                char character = Convert.ToChar(Console.ReadLine().ToLower());

                bool foundcharacterInWord = false;

                for(int i = 0; i < word.Length; i++)
                {
                    if (word[i] == character)
                    {
                        foundcharacterInWord = true;
                        break;
                    }
                }

                string tempHiddenWord = hiddenWord;
                hiddenWord = "";

                if(foundcharacterInWord)
                {
                    for(int i = 0; i < word.Length; i++)
                    {
                        if(word[i] == character)
                        {
                            hiddenWord += character;
                        }
                        else if (tempHiddenWord[i] != '_')
                        {
                            hiddenWord += tempHiddenWord[i];
                        }
                        else
                        {
                            hiddenWord += '_';
                        }
                    }

                    if (hiddenWord == word)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Gewonnen!");
                        Console.WriteLine("Das Wort war: " + word);
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    hiddenWord = tempHiddenWord;

                    if(Lives > 0)
                    {
                        Lives -= 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("GAMWE OVER!!");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                }
            }
        }
    }
}
