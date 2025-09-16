using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAGI_Opgave
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            bool rigtigtSvar = false; 
            // Her kommer et while loop som vurderer om den indtastede værdi er korrekt eller falsk
            while (rigtigtSvar == false)
            {
                // HER KOMMER TEKST TIL MENUEN I KONSOLEN
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Marcus' Spil");
                Console.WriteLine("2. Martins Spil");

                Console.WriteLine("3. Afslut programmet");
                // VI GEMMER BRUGERENS RESPONS FRA KONSOLEN I EN STRING
                string userResponse = Console.ReadLine();
                // isNumber er en bool, som fortæller om TryParse af stringen userResponse kan laves til en integer, derudover får vi også en integer kaldet userResponseInteger
                bool isNumber = int.TryParse(userResponse, out int userResponseInteger);
                // her er en if statement som tjekker om den indskrevne værdi er et tal
                if (isNumber == true)
                {
                    switch (userResponseInteger)
                    {
                        case 1:
                            Console.Clear();
                            MarcusGame();
                            rigtigtSvar = true;
                            break;
                        case 2:
                            Console.Clear();
                            MartinsGame();
                           // rigtigtSvar = true;
                            break;
                        default:
                            Console.WriteLine("Tallet er ikke 1 eller 2");
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Programmet er slut");
                            rigtigtSvar = true;
                            break;
                    }
                }
                // Her er en else statement som køres hvis det ikke er et tal
                else {
                    Console.WriteLine("Beklager, dit input er ikke et tal");
                
                }
            }

        }
 
        static void MarcusGame()
        {
            // Gæt et tal
            Console.WriteLine("Gæt et tal");



        }



        static void MartinsGame()
        {
            Console.WriteLine("Martins Funhouse");
            Console.WriteLine("1. Hangman (In progress)");
            Console.WriteLine("2. MineSweeper (Not started)");
            Console.WriteLine("3. Battleship (Not started)");
            Console.WriteLine("4. Rock, Paper, Scissor (Not imported yet)");
            Console.WriteLine("5. Tic-Tac-Toe (Not imported yet)");
            Console.WriteLine("6. Exit");

            bool keepRunningMartinsGame = true;



            while(keepRunningMartinsGame)
            {
                string menuResponse = Console.ReadLine().Trim();
                bool menuResponseIsNumber = int.TryParse(menuResponse, out int menuResponseNumber);

                if (menuResponseIsNumber) 
                {
                    switch(menuResponseNumber)
                    {
                        case 1:
                            Console.Clear();
                            MartinsGameHangman();
                            break;
                        case 2:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Please pick a number on the list...");
                            break;
                    }
                    keepRunningMartinsGame = false;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Your input is not a valid number, please try again");
                }
            }


        }
        static void MartinsGameHangman()
        {
            
            Console.Clear();
            Console.WriteLine("Welcome to Hangman");
        }

    }
}
