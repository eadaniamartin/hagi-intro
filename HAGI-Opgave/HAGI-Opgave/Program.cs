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
            
            // Her kommer et while loop som vurderer om den indtastede værdi er korrekt eller falsk
            while (true)
            {
                // VI GEMMER BRUGERENS RESPONS FRA KONSOLEN I EN STRING
                string userResponse = Console.ReadLine();
                // isNumber er en bool, som fortæller om TryParse af stringen userResponse kan laves til en integer, derudover får vi også en integer kaldet userResponseInteger
                bool isNumber = int.TryParse(userResponse, out int userResponseInteger);
                // her er en if statement som tjekker om den indskrevne værdi er et tal og om det er 1 eller 2
                if (isNumber && userResponseInteger == 1 | userResponseInteger == 2)
                {
                    Console.WriteLine($"Number: {userResponseInteger}");
                    break;
                }
                // 
                else {
                    Console.WriteLine("Beklager, dit input er ikke et tal");
                
                }
            }


            Console.WriteLine("Perfekt du er kommet ud af loopet");


            //for (int i = 0; i < 10; i++) {
            //    Console.WriteLine(i);
            //}


        }
    }
}
