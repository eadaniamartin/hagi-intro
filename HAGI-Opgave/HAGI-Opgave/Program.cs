using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Emit;
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
            int maxTries = 5;
            int tries = 0;


            bool isCorrect = false;

            while (isCorrect == false) 
            {
                Console.WriteLine($"Du har {maxTries} forsøg. Du har brugt {tries} forsøg");
                Console.WriteLine(" = Gæt et tal mellem 1-20 = ");
                userGuess = Console.ReadLine();
                bool userInput= int.TryParse(userGuess, out int userGuessInteger);

                if (userInput == true)
                {
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
                else if (userInput == false)
                {
                    Console.WriteLine("Du skal skrive et tal");
                }

            }
            Console.WriteLine("Tryk på valgfri knap for at vende tilbage til menu");
            Console.ReadKey();
            Console.Clear();


        }

        static void SecondDifficultyMarcusGame()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 51);
            string userGuess;
            int maxTries = 10;
            int tries = 0;


            bool isCorrect = false;

            while (isCorrect == false)
            {
                Console.WriteLine($"Du har {maxTries} forsøg. Du har brugt {tries} forsøg");
                Console.WriteLine(" = Gæt et tal mellem 1-50 = ");
                userGuess = Console.ReadLine();
                bool userInput = int.TryParse(userGuess, out int userGuessInteger);

                if (userInput == true)
                {
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
                else if (userInput == false)
                {
                    Console.WriteLine("Du skal skrive et tal");
                }

            }
            Console.WriteLine("Tryk på valgfri knap for at vende tilbage til menu");
            Console.ReadKey();
            Console.Clear();
        }

        static void ThirdDifficultyMarcusGame()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            string userGuess;
            int maxTries = 15;
            int tries = 0;


            bool isCorrect = false;

            while (isCorrect == false)
            {
                Console.WriteLine($"Du har {maxTries} forsøg. Du har brugt {tries} forsøg");
                Console.WriteLine(" = Gæt et tal mellem 1-100 = ");
                userGuess = Console.ReadLine();
                bool userInput = int.TryParse(userGuess, out int userGuessInteger);

                if (userInput == true)
                {
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
                else if (userInput == false)
                {
                    Console.WriteLine("Du skal skrive et tal");
                }

            }
            Console.WriteLine("Tryk på valgfri knap for at vende tilbage til menu");
            Console.ReadKey();
            Console.Clear();
        }


        static void MartinsGame()
        {
            bool keepRunningMartinsGame = true;
            while (keepRunningMartinsGame)
            {
                ConsoleColor originalConsoleForegroundColor = Console.ForegroundColor;
                ConsoleColor originalConsoleBackgroundColor = Console.BackgroundColor;

                Console.WriteLine("| Martins Funhouse");
                Console.WriteLine("|------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("| 1. Hangman (Gul - Under udvikling)");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("| 2. Minesweeper (Rød - Færdig)");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("| 3. Battleship (Gul - Under udvikling)");
                Console.WriteLine("| 4. Rock, Paper, Scissor (Gul - Under udvikling)");
                Console.WriteLine("| 5. Tic-Tac-Toe (Gul - Under udvikling)");
                Console.ForegroundColor = originalConsoleForegroundColor;
                Console.WriteLine("| 6. Exit");

                string menuResponse = Console.ReadLine().Trim();
                bool menuResponseIsNumber = int.TryParse(menuResponse, out int menuResponseNumber);

                if (menuResponseIsNumber)
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
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                keepRunningMartinsGame = false;
                                break;
                            default:
                                Console.WriteLine("Please pick a number on the list...");
                                break;
                        }
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

        static void MineSweeper()
        {
            byte gameGridRows = 20;
            byte gameGridCols = 20;
            ushort boardFieldsLeft = (ushort)(gameGridRows * gameGridCols);
            ushort boardFieldsTaken = 0;
            byte gameAmountOfMines = 30;
            bool gameIsDone = false;
            bool dead = false;

            GridType[,] gridArrayBoard = new GridType[gameGridRows, gameGridCols];
            bool[,] gridVisible = new bool[gameGridRows, gameGridCols];
            byte[,] gridValue = new byte[gameGridRows, gameGridCols];

            DistributeMinesEvenly(gridArrayBoard, gameAmountOfMines, gameGridRows, gameGridCols);
            DrawMinesweeperBoard(gridArrayBoard, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);

            while(!gameIsDone && !dead)
            {
                var userCoordinate = PromptUserForRowAndCol(gameGridRows, gameGridCols);
                bool positionIsVisible = CheckIfPositionIsAlreadyVisible(gridVisible, userCoordinate);
                bool positionIsAMine = CheckIfPositionIsMine(gridArrayBoard, userCoordinate.row, userCoordinate.col);

                // abstracted for at separere logik fra redraw funktionen.
                SetGridPositionValue(gridArrayBoard, gridValue, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                // også abstracted fra redraw.
                SetGridPositionVisibility(gridVisible, true, userCoordinate.row, userCoordinate.col);

                boardFieldsLeft--;
                boardFieldsTaken++;
                if (!positionIsVisible && !positionIsAMine)
                {
                    byte numberOfMinesAroundPosition = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                    RedrawMinesweeperBoard(gridArrayBoard, userCoordinate, numberOfMinesAroundPosition, gridVisible, gridValue, gameGridRows, gameGridCols, positionIsAMine, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);
                }
                else if(positionIsAMine)
                {
                    dead = true;
                    gameIsDone = true;
                    byte numberOfMinesAroundPosition = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                    RedrawMinesweeperBoard(gridArrayBoard, userCoordinate, numberOfMinesAroundPosition, gridVisible, gridValue, gameGridRows, gameGridCols, positionIsAMine, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);
                    Console.WriteLine("You died!");
                    Console.WriteLine("Press any key to continue back to menu");
                    Console.ReadKey();
                }
                else if(boardFieldsLeft == gameAmountOfMines && dead == false)
                {
                    gameIsDone = true;
                    byte numberOfMinesAroundPosition = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                    RedrawMinesweeperBoard(gridArrayBoard, userCoordinate, numberOfMinesAroundPosition, gridVisible, gridValue, gameGridRows, gameGridCols, positionIsAMine, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);
                    Console.WriteLine("You won! Congratulations");
                    Console.WriteLine("Press any key to continue back to menu");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Please choose a position that hasn't been chosen before");
                }
            }
        }

        static void DistributeMinesEvenly(GridType[,] board, byte amountOfMines, byte maxRows, byte maxCols)
        {
            Random random = new Random();
            for (int i = 0; i < amountOfMines; i++)
            {
                while(true)
                {
                    byte randomRow = (byte)random.Next(0, maxRows);
                    byte randomCol = (byte)random.Next(0, maxCols);

                    if(!CheckIfPositionIsMine(board, randomRow, randomCol))
                    {
                        board[randomRow,randomCol] = GridType.Mine;
                        break;
                    }

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
                
                if (userRowResponseIsNumber)
                {
                    if (userRowNumber >= 0 & userRowNumber <= (rows-1))
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
                    if(userColNumber >= 0 & userColNumber <= (cols-1))
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
            return (userRowNumber, userColNumber);
        }

        static void DrawMinesweeperBoard(GridType[,] gridArrayBoard, ushort fieldsLeft, ushort fieldsTaken, byte amountOfMines)
        {
            ConsoleColor originalConsoleBackgroundColor = Console.BackgroundColor;
            ConsoleColor originalConsoleForegroundColor = Console.ForegroundColor;
            
            Console.Write($"\n      Fields left: {fieldsLeft}       Fields taken: {fieldsTaken}       Mines: {amountOfMines}\n\n");


            for (int i = 0; i < gridArrayBoard.GetLength(0); i++)
            {
                Console.ForegroundColor = originalConsoleForegroundColor;
                if (i >= 10)
                {
                    Console.Write($" {i}   ");

                }
                else
                {
                    Console.Write($" {i}    ");
                }
                Console.ForegroundColor = ConsoleColor.Black;
                for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("[ ]");
                    Console.BackgroundColor = originalConsoleBackgroundColor;
                }
                Console.Write("\n");
            }
            Console.ForegroundColor = originalConsoleForegroundColor;
            Console.Write($"      ");
            for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
            {
                if (j >= 10)
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

        static void SetGridPositionValue(GridType[,] board, byte[,] gridValue, byte row, byte col, byte maxRowSize, byte maxColSize)
        {
            gridValue[row, col] = CheckSurroundingPositions(board, row, col, maxRowSize, maxColSize);
        }

        static void SetGridPositionVisibility(bool[,] gridVisible, bool b, byte row, byte col)
        {
            gridVisible[row, col] = b;
        }

        static void RedrawMinesweeperBoard(GridType[,] gridArrayBoard, (byte row, byte col) userCoordinate, byte positionNumber, bool[,] gridVisible, byte[,] gridValue, byte maxRowSize, byte maxColSize, bool positionIsAMine, ushort fieldsLeft, ushort fieldsTaken, byte amountOfMines)
        {
            ConsoleColor originalConsoleBackgroundColor = Console.BackgroundColor;
            ConsoleColor originalConsoleForegroundColor = Console.ForegroundColor;

            Console.Clear();

            Console.Write($"\n      Fields left: {fieldsLeft}       Fields taken: {fieldsTaken}       Mines: {amountOfMines}\n\n");
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
                Console.ForegroundColor = ConsoleColor.Black;                 
                for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
                {

                    Console.BackgroundColor = ConsoleColor.Black;
                    if (i == userCoordinate.row && j == userCoordinate.col)
                    {
                        if (positionIsAMine)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("[B]");
                            Console.BackgroundColor = originalConsoleBackgroundColor;
                        }
                        else
                        {
                            if (positionNumber == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write($"[-]");
                                Console.BackgroundColor = originalConsoleBackgroundColor;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write($"[{positionNumber}]");
                                Console.BackgroundColor = originalConsoleBackgroundColor;
                            }

                        } 
                    }
                    else
                    {
                        if (gridVisible[i, j] == true)
                        {
                            if (gridValue[i, j] == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("[-]");
                                Console.BackgroundColor = originalConsoleBackgroundColor;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write($"[{gridValue[i, j]}]");
                                Console.BackgroundColor = originalConsoleBackgroundColor;

                            }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("[ ]");
                            Console.BackgroundColor = originalConsoleBackgroundColor;    
                        }
                    }
                }
                Console.Write("\n");
                Console.ForegroundColor = originalConsoleForegroundColor;
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

        static bool IsInsideBounds(int row, int col, int maxRows, int maxCols)
        {
            return row >= 0 && row < maxRows && col >= 0 && col < maxCols;
        }


        static byte CheckSurroundingPositions(GridType[,] gridArray, byte row, byte col, byte maxRowSize, byte maxColSize)
        {
            byte countAmountOfMines = 0;

            int[,] directions = new int[,]
            {
                {-1, -1}, {-1, 0}, {-1, 1},  // ØVRE ROW
                { 0, -1},          { 0, 1},  // MIDT ROW
                { 1, -1}, { 1, 0}, { 1, 1}   // NEDRE ROW
            };

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newRow = row + directions[i, 0];
                int newCol = col + directions[i, 1];

                if (IsInsideBounds(newRow, newCol, maxRowSize, maxColSize))
                {
                    if (gridArray[newRow, newCol] == GridType.Mine)
                        countAmountOfMines++;
                }
            }
            return countAmountOfMines;
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
