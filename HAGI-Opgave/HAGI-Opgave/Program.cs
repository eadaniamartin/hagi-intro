using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
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
                            // rigtigtSvar = true;
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
                else
                {
                    Console.WriteLine("Beklager, dit input er ikke et tal");

                }
            }

        }

        static void MarcusGame()
        {

            bool keepRunningMarcusGame = true;

            while (keepRunningMarcusGame)
            {
                Console.WriteLine("=== GÆT ET TAL ===");
                Console.WriteLine("Vælg mellem 3 sværhedsgrader");
                Console.WriteLine("1. = 1-20 =");
                Console.WriteLine("2. = 1-50 =");
                Console.WriteLine("3. = 1-100 =");
                Console.WriteLine("4. Gå til menu");

                string userResponse = Console.ReadLine();
                bool response = int.TryParse(userResponse, out int responseInteger);

                if (response == true)
                {
                    switch (responseInteger)
                    {
                        case 1:
                            Console.Clear();
                            FirstDifficultyMarcusGame();
                            break;
                        case 2:
                            Console.Clear();
                            SecondDifficultyMarcusGame();
                            break;
                        case 3:
                            Console.Clear();
                            ThirdDifficultyMarcusGame();
                            break;
                        case 4:
                            keepRunningMarcusGame = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Beklager, dit input er ikke en valgmulighed");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Beklager, dit input er ikke en valgmulighed");
                }

            }


        }

        static void FirstDifficultyMarcusGame()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 21);
            string userGuess;
            int maxTries = 7;
            int tries = 0;


            bool isCorrect = false;

            while (isCorrect == false) 
            {
                Console.WriteLine($"Du har {maxTries} forsøg. Du har brugt {tries} forsøg");
                Console.WriteLine(" = Gæt et tal mellem 1-20 = ");
                userGuess = Console.ReadLine();
                bool userInput= int.TryParse(userGuess, out int userGuessInteger);

                if (userGuessInteger == randomNumber)
                {
                    Console.Clear();
                    Console.WriteLine(" ==== TILLYKKE DU HAR VUNDET ==== ");
                    isCorrect = true;
                }
                else if (userGuessInteger < randomNumber)
                {
                    Console.WriteLine("Dit gæt er for lavt");
                }
                else if (userGuessInteger > randomNumber)
                {
                    Console.WriteLine("Dit gæt er for højt");
                }
                if (isCorrect == false)
                {
                    tries++;
                }
                if (maxTries == tries)
                {
                    Console.Clear();
                    Console.WriteLine("Du har tabt");
                    break;
                }

            }
            Console.WriteLine("Tryk på valgfri knap for at vende tilbage til menu");
            Console.ReadKey();
            Console.Clear();


        }

        static void SecondDifficultyMarcusGame()
        {
            Console.WriteLine(" = Gæt et tal mellem 1-50 = ");
            Console.ReadLine();
        }

        static void ThirdDifficultyMarcusGame()
        {
            Console.WriteLine(" = Gæt et tal mellem 1-100 = ");
            Console.ReadLine();
        }


        static void MartinsGame()
        {
            Console.WriteLine("| Martins Funhouse");
            Console.WriteLine("|------------------------------------------------");
            Console.WriteLine("| 1. Hangman (In progress)");
            Console.WriteLine("| 2. MineSweeper (Not started)");
            Console.WriteLine("| 3. Battleship (Not started)");
            Console.WriteLine("| 4. Rock, Paper, Scissor (Not imported yet)");
            Console.WriteLine("| 5. Tic-Tac-Toe (Not imported yet)");
            Console.WriteLine("| 6. Exit");

            bool keepRunningMartinsGame = true;


            while (keepRunningMartinsGame)
            {
                string menuResponse = Console.ReadLine().Trim();
                bool menuResponseIsNumber = int.TryParse(menuResponse, out int menuResponseNumber);

                if (menuResponseIsNumber)

                    while (keepRunningMartinsGame)
                    {
                        string response = Console.ReadLine();
                        if (response.Trim().ToLower() == "q")

                        {
                            switch (menuResponseNumber)
                            {
                                case 1:
                                    Console.Clear();
                                    MartinsGameHangman();
                                    break;
                                case 2:
                                    Console.Clear();
                                    MineSweeper();
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
        }

        static void MartinsGameHangman()
        {
            
            Random random = new Random();
            int randomNumber = random.Next(0, 20);

            Console.Clear();
            Console.WriteLine("Welcome to Hangman");

            string[] wordsArray = {
                "hospitalsseng",    // 0
                "skattejagt",       // 1
                "flyvemaskine",     // 2
                "flagstang",        // 3
                "lynlås",           // 4
                "vinterjakke",      // 5
                "stjerneskud",      // 6
                "computerspil",     // 7
                "cirkusklovn",      // 8
                "brødrister",       // 9
                "vinduesramme",     // 10
                "teaterstykke",     // 11
                "lommelygte",       // 12
                "postkasse",        // 13
                "sommerfugl",       // 14
                "fødselsdag",       // 15
                "køleskab",         // 16
                "skrivebord",       // 17
                "svømmehal",        // 18
                "kaffekande"        // 19
            };


            Console.WriteLine(randomNumber);
            Console.WriteLine(wordsArray[randomNumber]);



            MartinsGameHangmanDraw(wordsArray[randomNumber]);






            Console.ReadLine();
        }

        static char MartinsGameHangmanPromptUserChar()
        {
            //while (true) {
            //    ConsoleKeyInfo key = Console.ReadKey();
            //    char charGuess = key.KeyChar;
            //    bool isAcceptedLetterType = char.IsLetter(charGuess);

            //    if (isAcceptedLetterType)
            //    {
            //        Console.WriteLine($"\nCharacter guess: {charGuess}");
            //        return 

            //    }

            //}
            char dwadd = Convert.ToChar("d");
            return dwadd;
        }

        static void MartinsGameHangmanDraw(string word)
        {
            MartinsGameHangmanDrawHangman();
            MartinsGameHangmanDrawWordPlacings(word);
        }

        static void MartinsGameHangmanDrawHangman()
        {
            Console.WriteLine(@"   ________  ");
            Console.WriteLine(@"   |    \ |  ");
            Console.WriteLine(@"   O     \|  ");
            Console.WriteLine(@"  /|\     |  ");
            Console.WriteLine(@"  / \     |  ");
            Console.WriteLine(@"          |  ");
            Console.WriteLine(@"-------------");
        }

        enum GridType
        {
            None,
            Mine
        }

        enum GridVisibility
        {
            Invisible,
            Visible,
        }

        static void MineSweeper()
        {
            Random random = new Random();
            byte gameGridRows = 20;
            byte gameGridCols = 20;
            byte gameAmountOfMines = 10;
            bool dead = false;

            GridType[,] gridArrayBoard = new GridType[gameGridRows, gameGridCols];
            bool[,] gridVisible = new bool[gameGridRows, gameGridCols];
            byte[,] gridValue = new byte[gameGridRows, gameGridCols];


            for (int i = 0; i < gameAmountOfMines; i++)
            {
                gridArrayBoard[random.Next(0, gameGridRows), random.Next(0, gameGridCols)] = GridType.Mine;
            }

            DrawMineSweeperBoard(gridArrayBoard);

            bool gameIsDone = false;

            while(!gameIsDone && !dead)
            {
                var userCoordinate = PromptUserForRowAndCol(gameGridRows, gameGridCols);
                bool isVisible = CheckIfPositionIsAlreadyVisible(gridVisible, userCoordinate);
                if(!isVisible)
                {
                    Console.WriteLine($"Coordinate... Row: {userCoordinate.row}   Col: {userCoordinate.col}");
                    byte numberOfMinesAroundPosition = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                    Console.WriteLine($"WDJidjwaijdda {numberOfMinesAroundPosition}");
                    RedrawMineSweeperBoard(gridArrayBoard, userCoordinate, numberOfMinesAroundPosition, gridVisible, gridValue, gameGridRows, gameGridCols, dead);
                    if(dead) { Console.WriteLine("You died"); }
                }
                else
                {
                    Console.WriteLine("Please choose a position that hasn't been chosen before");
                }
            }

        }

        static (byte row, byte col) PromptUserForRowAndCol(byte rows, byte cols)
        {
            byte userRowNumber;
            byte userColNumber;
            while(true)
            {
                Console.Write($"Row between 0-{(rows-1)}: ");
                string userRowResponse = Console.ReadLine();
                bool userRowResponseIsNumber = byte.TryParse(userRowResponse, out userRowNumber);
                //if (userRowResponseIsNumber)
                //{
                //    Console.WriteLine($"Row: {userRowNumber}");
                //}
                //else
                //{
                //    Console.WriteLine("Wrong input");
                //}
                if (userRowResponseIsNumber)
                {
                    if (userRowNumber > 0 & userRowNumber <= rows)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please stay within the number range");
                    }
                }
                else
                {
                    Console.WriteLine("Please input valid numbers");
                }
            }
            while(true)
            {
                Console.Write($"\nCol between 0-{(cols-1)}: ");
                string userColResponse = Console.ReadLine();
                bool userColResponseIsNumber = byte.TryParse(userColResponse, out userColNumber);
                if(userColResponseIsNumber)
                {
                    if(userColNumber > 0 & userColNumber <= cols)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please stay within the number range");
                    }
                }
                else
                {
                    Console.WriteLine("Please input valid numbers");
                }
            }
            
            //if (userColResponseIsNumber)
            //{
            //    Console.WriteLine($"Row: {userColNumber}");
            //}
            //else
            //{
            //    Console.WriteLine("Wrong input");
            //}


            return (userRowNumber, userColNumber);
        }

        static void DrawMineSweeperBoard(GridType[,] gridArrayBoard)
        {
            for (int i = 0; i < gridArrayBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
                {    
                    Console.Write("[ ]"); 
                }
                Console.Write("\n");
            }

        }


        static void RedrawMineSweeperBoard(GridType[,] gridArrayBoard, (byte row, byte col) userCoordinate, byte positionNumber, bool[,] gridVisible, byte[,] gridValue, byte maxRowSize, byte maxColSize, bool dead)
        {
            Console.Clear();
            for (int i = 0; i < gridArrayBoard.GetLength(0); i++)
            {
                if(i >= 10)
                {
                    Console.Write($" {i}   ");

                }
                else
                {
                    Console.Write($" {i}    ");
                }
                    for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
                    {
                        if (i == userCoordinate.row && j == userCoordinate.col)
                        {
                            bool isPositionMine = CheckIfPositionIsMine(gridArrayBoard, userCoordinate.row, userCoordinate.col);
                            gridValue[i, j] = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, maxRowSize, maxColSize);
                            gridVisible[i, j] = true;

                            if (isPositionMine)
                            {
                                Console.Write("[B]");
                                dead = true;
                            }
                            else if (positionNumber == 0)
                            {
                                Console.Write($"[-]");
                            }
                            else
                            {

                                Console.Write($"[{positionNumber}]");
                            }

                        }
                        else
                        {
                            if (gridVisible[i, j] == true)
                            {
                                if (gridValue[i, j] == 0)
                                {
                                    Console.Write("[-]");
                                }
                                else
                                {
                                    Console.Write($"[{gridValue[i, j]}]");
                                }
                            }
                            else
                            {
                                Console.Write("[ ]");
                            }
                        }
                    }
                Console.Write("\n");
            }
            Console.Write($"      ");
            for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
            {
                if(j >= 10)
                {
                    Console.Write($"{j} ");
                }
                else
                {
                    Console.Write($" {j} ");
                }
            }
            Console.Write("\n");
        }

        static bool CheckIfPositionIsAlreadyVisible(bool[,] gridVisible, (byte row, byte col) userCoordinate)
        {
            if(gridVisible[userCoordinate.row, userCoordinate.col])
            {
                return true;
            }
            return false;
        }

        static bool CheckIfPositionIsMine(GridType[,] gridArray, byte row, byte col)
        {
            if (gridArray[row, col] == GridType.Mine)
            {
                return true;
            }
            return false;
        }

        static byte CheckSurroundingPositions(GridType[,] gridArray, byte row, byte col, byte maxRowSize, byte maxColSize)
        {
            byte amountOfSurroundingMines = 0;

            int upperRow = row - 1;
            int lowerRow = row + 1;

            int leftCol = col - 1;
            int rightCol = col + 1;

            bool isUpperRowAvailable = (upperRow >= 0);
            bool isLowerRowAvailable = (lowerRow <= maxRowSize);
            bool isLeftColAvailable = (leftCol >= 0);
            bool isRightColAvailable = (rightCol <= maxColSize);

            int checksAmount = 0;

            GridType[] checksArray = new GridType[8];

            if(isUpperRowAvailable)
            {
                if(isLeftColAvailable)
                {
                    checksArray[checksAmount] = gridArray[upperRow, leftCol];   // ØVRE VENSTRE
                    checksAmount++;
                }
                if(isRightColAvailable)
                {
                    checksArray[checksAmount] = gridArray[upperRow, rightCol];   // ØVRE HØJRE
                    checksAmount++;
                }
                checksArray[checksAmount] = gridArray[(row - 1), (col)];       // ØVRE MIDT
                checksAmount++;
            }

            if(isLeftColAvailable)
            {
                checksArray[checksAmount] = gridArray[(row), (col - 1)];       // MIDT VENSTRE
                checksAmount++;
            }
            if(isRightColAvailable)
            {
                checksArray[checksAmount] = gridArray[(row), (col + 1)];       // MIDT HØJRE
                checksAmount++;
            }
            if(isLowerRowAvailable)
            {
                if (isLeftColAvailable)
                {
                    checksArray[checksAmount] = gridArray[(row + 1), (col - 1)];   // NEDRE VENSTRE
                    checksAmount++;
                }
                if (isRightColAvailable)
                {
                    checksArray[checksAmount] = gridArray[(row + 1), (col + 1)];   // NEDRE HØJRE
                    checksAmount++;
                }
                checksArray[checksAmount] = gridArray[(row + 1), (col)];       // NEDRE MIDT
                checksAmount++;
            }

            //checksArray[0] = gridArray[(row - 1), (col - 1)];   // ØVRE VENSTRE
            //checksArray[1] = gridArray[(row - 1), (col)];       // ØVRE MIDT
            //checksArray[2] = gridArray[(row - 1), (col + 1)];   // ØVRE HØJRE
            //checksArray[3] = gridArray[(row), (col - 1)];       // MIDT VENSTRE
            ////GridType upperleft = gridArray[(row), (col)];        SAMME KOORDINAT
            //checksArray[4] = gridArray[(row), (col + 1)];       // MIDT HØJRE
            //checksArray[5] = gridArray[(row + 1), (col - 1)];   // NEDRE VENSTRE
            //checksArray[6] = gridArray[(row + 1), (col)];       // NEDRE MIDT
            //checksArray[7] = gridArray[(row + 1), (col + 1)];   // NEDRE HØJRE

            for (int i = 0; i < 8; i++)
            {
                if (checksArray[i] == GridType.Mine)
                {
                    amountOfSurroundingMines++;
                }
            }

            return amountOfSurroundingMines;
        }

        static void MartinsGameHangmanDrawWordPlacings(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Console.Write(" _");
            }
            Console.Write(" \n\n");
        }

    }
}
