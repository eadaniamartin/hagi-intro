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
            // HER KOMMER TEKST TIL MENUEN I KONSOLEN
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Marcus' Spil");
            Console.WriteLine("2. Martins Spil");
            bool rigtigtSvar = false; 
            // Her kommer et while loop som vurderer om den indtastede værdi er korrekt eller falsk
            while (rigtigtSvar == false)
            {
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
                            rigtigtSvar = true;
                            break;
                        default:
                            Console.WriteLine("Tallet er ikke 1 eller 2");
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
            Console.WriteLine("Marcus spil");




        }

        static void MartinsGame()
        {
            Console.WriteLine("Martins spil");

            while(true)
            {
                string response = Console.ReadLine();
                if (true)
                {
                    break;
                }
            }

        }
    }
}
