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
            Console.WriteLine("Martins spil");

            bool keepRunningMartinsGame = true;

            while(keepRunningMartinsGame)
            {
                string response = Console.ReadLine();
                if (response.Trim().ToLower() == "q") 
                {
                    keepRunningMartinsGame = false;
                    Console.Clear();
                }
            }

        }
    }
}
