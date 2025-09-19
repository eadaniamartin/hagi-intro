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
            // Fælles kodedel

            bool keepProgramRunning = true;
            // Her kommer et while loop som vurderer om den indtastede værdi er korrekt eller falsk
            while (keepProgramRunning == true)
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
                            break;
                        case 2:
                            Console.Clear();
                            MartinsGame();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Programmet er slut");
                            keepProgramRunning = false;
                            break;
                        default:
                            Console.WriteLine("Tallet er ikke 1 eller 2");
                            break;
                    }
                }
                // Her er en else statement som køres, hvis userResponse ikke er et tal
                else
                {
                    Console.WriteLine("Beklager, dit input er ikke et tal");

                }
            }

        }



        // Kommentarer til Marcus kodedel

        // Her er MarcusGame som er den funktion der kører mit spils menu, når den bliver kaldt oppe i den fælles menu
        // Heri er der mulighed for at vælge mellem 3 forskellige sværhedsgrader som hver især består af en funktion der bliver kaldt gennem menuen
        static void MarcusGame()
        {

            bool keepRunningMarcusGame = true;
            // Her er et while loop der køres når keepRunningMarcusGame er true, hvilket bruges til at holde menuen og spillet igang indtil brugeren afslutter
            while (keepRunningMarcusGame)
            {
                Console.WriteLine("=== GÆT ET TAL ===");
                Console.WriteLine("Vælg mellem 3 sværhedsgrader");
                Console.WriteLine("1. = 1-20 =");
                Console.WriteLine("2. = 1-50 =");
                Console.WriteLine("3. = 1-100 =");
                Console.WriteLine("4. Gå til menu");
                // Her har jeg sat spillerens indput til at blive gemt i stringen userResponse
                string userResponse = Console.ReadLine();
                // Her bruger jeg stringen userResponse for at konvertere indputtet til en integer gemt i responseInteger.
                // Derudover får vi en sand eller falsk værdi på om konverteringen er lykkedes, og gemmes i response af typen bool 
                bool response = int.TryParse(userResponse, out int responseInteger);
                // Her er en if statement som kører en switch case hvis den førnævnte konvertering lykkedes
                if (response == true)
                {   // Her er en switch case som sammenligner brugerens indput med de muligheder der er stillet til rådighed i menuen, sådan at programmet kan køre brugerens valg
                    switch (responseInteger)
                    {   // Her er case 1-3 som fører brugeren hen til den valgte sværhedsgrad når de bliver aktiveret
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
                        case 4: // Her er case 4 som ændrer keepRunningMarcusGame til false og dermed afslutter while loopet således at brugeren bliver sendt tilbage til hovedmenuen
                            keepRunningMarcusGame = false;
                            Console.Clear();
                            break;
                        default: // Her er en default som håndterer alt det indput som ikke aktiverer case 1-4 
                            Console.WriteLine("Beklager, dit input er ikke en valgmulighed");
                            break;
                    }
                }
                else // Her er else der kører hvis konverteringen fra string til int ikke lykkedes 
                {
                    Console.WriteLine("Beklager, dit input er ikke en valgmulighed");
                }

            }


        }

        static void FirstDifficultyMarcusGame()
        {   // Her er sværhedsgradens primære variabler
            Random random = new Random();
            int randomNumber = random.Next(1, 21);
            string userGuess;
            int maxTries = 5;
            int tries = 0;


            bool isCorrect = false;
            // Her er et while loop som sørger for at så længe der kommer forkert svar fra spilleren, så kører den igen
            while (isCorrect == false) 
            {
                Console.WriteLine($"Du har {maxTries} forsøg. Du har brugt {tries} forsøg");
                Console.WriteLine(" = Gæt et tal mellem 1-20 = ");
                // brugerens indput gemmes i userGuess som er defineret i denne sværhedsgrads primære variabler
                userGuess = Console.ReadLine();
                // her konverterer jeg userGuess fra string til Integer og gemmer indputtet i userGuessInteger
                // derudover bliver der også vurderet på om konverteringen lykkedes og det bliver gemt i userInput som er en bool
                bool userInput= int.TryParse(userGuess, out int userGuessInteger);
                // her er en if statement som kører en switch case hvis konverteringen lykkedes
                if (userInput == true)
                {   
                    if (userGuessInteger == randomNumber)
                    {
                        // her er en if statement som køres hvis brugeren indtaster det rigtige svar og dermed bryder while loopet fordi isCorrect bliver lavet om til true
                        // dette betyde også at brugeren har besejret sværhedsgraden
                        Console.Clear();
                        Console.WriteLine(" ==== TILLYKKE DU HAR VUNDET ==== ");
                        isCorrect = true;
                    }
                    else if (userGuessInteger < randomNumber)
                    { // denne else if statement aktiveres hvis spillerens indput er lavere end det genererede tal
                        Console.WriteLine("Dit gæt er for lavt");
                    }
                    else if (userGuessInteger > randomNumber)
                    { // denne else if statement aktiveres hvis spillerens indput er højere end det genererede tal
                        Console.WriteLine("Dit gæt er for højt");
                    }
                    if (isCorrect == false)
                    { // her er en if statement som aktiveres hvis spillerens indput er forkert
                      // dette medfører at variablen tries stiger med 1
                        tries++;
                    }
                    if (maxTries == tries)
                    { // her er en if statement som aktiveres hvis spilleren har brugt for mange forsøg som er når tries når samme antal som maxTries
                      // dette medfører at man har tabt spillet og dermed bryder ud af while loopet
                        Console.Clear();
                        Console.WriteLine("Du har tabt");
                        break;
                    }

                } // her er en else if statement som køres hvis brugeren ikke skriver et tal, herefter vil spilleren blive givet et forsøg mere på at skrive et tal
                else if (userInput == false)
                {
                    Console.WriteLine("Du skal skrive et tal");
                }

            }
            // når man er brudt ud af while loopet, bliver man bedt om at trykke på en knap for at vende tilbage til spilmenuen
            Console.WriteLine("Tryk på valgfri knap for at vende tilbage til menu");
            Console.ReadKey();
            Console.Clear();


        }

        static void SecondDifficultyMarcusGame()
        {   // Her er sværhedsgradens primære variabler
            Random random = new Random();
            int randomNumber = random.Next(1, 51);
            string userGuess;
            int maxTries = 10;
            int tries = 0;


            bool isCorrect = false;
            // Her er et while loop som sørger for at så længe der kommer forkert svar fra spilleren, så kører den igen
            while (isCorrect == false)
            {
                Console.WriteLine($"Du har {maxTries} forsøg. Du har brugt {tries} forsøg");
                Console.WriteLine(" = Gæt et tal mellem 1-50 = ");
                // brugerens indput gemmes i userGuess som er defineret i denne sværhedsgrads primære variabler
                userGuess = Console.ReadLine();
                // her konverterer jeg userGuess fra string til Integer og gemmer indputtet i userGuessInteger
                // derudover bliver der også vurderet på om konverteringen lykkedes og det bliver gemt i userInput som er en bool
                bool userInput = int.TryParse(userGuess, out int userGuessInteger);
                // her er en if statement som kører en switch case hvis konverteringen lykkedes
                if (userInput == true)
                {
                    if (userGuessInteger == randomNumber)
                    {
                        // her er en if statement som køres hvis brugeren indtaster det rigtige svar og dermed bryder while loopet fordi isCorrect bliver lavet om til true
                        // dette betyde også at brugeren har besejret sværhedsgraden
                        Console.Clear();
                        Console.WriteLine(" ==== TILLYKKE DU HAR VUNDET ==== ");
                        isCorrect = true;
                    }
                    else if (userGuessInteger < randomNumber)
                    {   // denne else if statement aktiveres hvis spillerens indput er lavere end det genererede tal
                        Console.WriteLine("Dit gæt er for lavt");
                    }
                    else if (userGuessInteger > randomNumber)
                    {   // denne else if statement aktiveres hvis spillerens indput er højere end det genererede tal
                        Console.WriteLine("Dit gæt er for højt");
                    }
                    if (isCorrect == false)
                    {   // her er en if statement som aktiveres hvis spillerens indput er forkert
                        // dette medfører at variablen tries stiger med 1
                        tries++;
                    }
                    if (maxTries == tries)
                    {   // her er en if statement som aktiveres hvis spilleren har brugt for mange forsøg som er når tries når samme antal som maxTries
                        // dette medfører at man har tabt spillet og dermed bryder ud af while loopet
                        Console.Clear();
                        Console.WriteLine("Du har tabt");
                        break;
                    }
                }   // her er en else if statement som køres hvis brugeren ikke skriver et tal, herefter vil spilleren blive givet et forsøg mere på at skrive et tal
                else if (userInput == false)
                {
                    Console.WriteLine("Du skal skrive et tal");
                }

            }   // når man er brudt ud af while loopet, bliver man bedt om at trykke på en knap for at vende tilbage til spilmenuen
            Console.WriteLine("Tryk på valgfri knap for at vende tilbage til menu");
            Console.ReadKey();
            Console.Clear();
        }

        static void ThirdDifficultyMarcusGame()
        {   // Her er sværhedsgradens primære variabler
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            string userGuess;
            int maxTries = 15;
            int tries = 0;


            bool isCorrect = false;
            // Her er et while loop som sørger for at så længe der kommer forkert svar fra spilleren, så kører den igen
            while (isCorrect == false)
            {
                Console.WriteLine($"Du har {maxTries} forsøg. Du har brugt {tries} forsøg");
                Console.WriteLine(" = Gæt et tal mellem 1-100 = ");
                // brugerens indput gemmes i userGuess som er defineret i denne sværhedsgrads primære variabler
                userGuess = Console.ReadLine();
                // her konverterer jeg userGuess fra string til Integer og gemmer indputtet i userGuessInteger
                // derudover bliver der også vurderet på om konverteringen lykkedes og det bliver gemt i userInput som er en bool
                bool userInput = int.TryParse(userGuess, out int userGuessInteger);
                // her er en if statement som kører en switch case hvis konverteringen lykkedes
                if (userInput == true)
                {
                    if (userGuessInteger == randomNumber)
                    {
                        // her er en if statement som køres hvis brugeren indtaster det rigtige svar og dermed bryder while loopet fordi isCorrect bliver lavet om til true
                        // dette betyde også at brugeren har besejret sværhedsgraden
                        Console.Clear();
                        Console.WriteLine(" ==== TILLYKKE DU HAR VUNDET ==== ");
                        isCorrect = true;
                    }
                    else if (userGuessInteger < randomNumber)
                    {   // denne else if statement aktiveres hvis spillerens indput er lavere end det genererede tal
                        Console.WriteLine("Dit gæt er for lavt");
                    }
                    else if (userGuessInteger > randomNumber)
                    {   // denne else if statement aktiveres hvis spillerens indput er højere end det genererede tal
                        Console.WriteLine("Dit gæt er for højt");
                    }
                    if (isCorrect == false)
                    {   // her er en if statement som aktiveres hvis spillerens indput er forkert
                        // dette medfører at variablen tries stiger med 1
                        tries++;
                    }
                    if (maxTries == tries)
                    {   // her er en if statement som aktiveres hvis spilleren har brugt for mange forsøg som er når tries når samme antal som maxTries
                        // dette medfører at man har tabt spillet og dermed bryder ud af while loopet
                        Console.Clear();
                        Console.WriteLine("Du har tabt");
                        break;
                    }
                }   // her er en else if statement som køres hvis brugeren ikke skriver et tal, herefter vil spilleren blive givet et forsøg mere på at skrive et tal
                else if (userInput == false)
                {
                    Console.WriteLine("Du skal skrive et tal");
                }

            }   // når man er brudt ud af while loopet, bliver man bedt om at trykke på en knap for at vende tilbage til spilmenuen
            Console.WriteLine("Tryk på valgfri knap for at vende tilbage til menu");
            Console.ReadKey();
            Console.Clear();
        }












        // ------------ MARTINS - NEDENFOR ER AL MARTINS KODE DEL -------------------

        // enum til at definere mulige værdier for positioner i 2D array boardet.
        enum GridType
        {
            None,
            Mine
        }

        // Funktion der indeholder hele min (Martin) spilmenu, og kaldes fra hovedmenuen i switch
        static void MartinsGame()
        {
            // bool som flag til at kontrollere hvornår while loop skal køre og afsluttes
            bool keepRunningMartinsGame = true;
            // while loop der kører så længe at keepRunningMartinsGame er true.
            // Menuen kører i et while loop for at menuen bliver ved med at køre, når man returnere fra selve spillet -
            // men også for at der kan laves validering på brugerens input, og prompte brugeren til at lave et nyt input, hvis det tidligere ikke var validt.
            while (keepRunningMartinsGame)
            {
                // Sætter nuværende console tekst og baggrundsfarve som variabler, så det er nemmere at sætte tilbage til original.
                // Da forskellige brugere kan have forskellige standard farver i deres konsol.
                // Her kunne jeg have lavet det til en funktion, men ja... det har jeg ikke fået gjort endnu.
                ConsoleColor originalConsoleForegroundColor = Console.ForegroundColor;
                ConsoleColor originalConsoleBackgroundColor = Console.BackgroundColor;

                // Selve konsol teksten der udskrives for at agere som menu og vise brugeren sine valgmuligheder -
                // Der er brugt lidt farve for at indikere sværhedsgraden på spillet
                Console.WriteLine("| Martins Funhouse");
                Console.WriteLine("|------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("| 1. Minesweeper (Rød - Færdig)");
                // Som nævnt tidligere, så bruger jeg det her til at sætte farven tilbage til den originale farve.
                Console.ForegroundColor = originalConsoleForegroundColor;
                Console.WriteLine("| 6. Exit");

                // Brugerens input fra ReadLine trimmes for whitespace og gemmes i variablen menuResponse af typen string.
                string menuResponse = Console.ReadLine().Trim();
                // Brugerens string input (menuResponse) bliver forsøgt konverteret til en integer (menuResponseNumber),
                // hvor return fra int.TryParse er en bool og gemmes i "menuResponseIsNumber", så jeg kan bruge boolen til validering.
                // Hvis true/sand så kunne menuResponse konverteres til en integer.
                bool menuResponseIsNumber = int.TryParse(menuResponse, out int menuResponseNumber);

                // Her sker valideringen i en if statement, som checker om boolen menuResponseIsNumber er true (altså om brugerens input kunne laves om til et validt integer)
                if (menuResponseIsNumber)
                {       
                    // Koden her kører kun, hvis brugerens tal inputt var validt
                    // Her bruges brugerens input til at se om det valide tal, matcher enten 1 (og kører Minesweeper), 6 (afslutter og vender tilbage til hovedmenuen)
                    // eller om inputtet er et andet tal end de to valgmuligheder
                    switch (menuResponseNumber)
                        {
                            case 1:
                                Console.Clear();
                                Minesweeper();
                                break;
                            case 6:
                                // Da denne valgmulighed skal afslutte spillet, så sættes boolen keepRunningMartingsGame (som bruges som flag i menuens while loop)
                                // til false, så at loopet ikke vil blive kørt igen.
                                keepRunningMartinsGame = false;
                                break;
                            // Default som kører hvis inputtet ikke matcher de andre 2 cases.
                            // Der gives en besked til brugeren om forkert tal og ellers så hopper vi tilbage til loopet og spørger forfra.
                            default:
                                Console.WriteLine("Please pick a number on the list...");
                                break;
                        }
                        // For bedre UX, så cleares konsollen.
                        Console.Clear();
                }
                // Hvis brugerens input ikke kunne laves om til et tal, og menuResponsIsNumber derfor er false,
                // så kører denne blok. Der gives besked om at inputtet ikke var validt, altså at det ikke var et tal.
                // Derefter ryger vi tilbage til starten af while loopet.
                else
                {
                    Console.WriteLine("Your input is not a valid number, please try again");
                }
            }
        }

        // Selve hjernen af spillet, hvor spillets regler opsættes. Når det kaldes så laves spillet og startes
        static void Minesweeper()
        {
            // Definering af lokale variabler der styrer spillets opbygning og "game state"
            byte gameGridRows = 20;
            byte gameGridCols = 20;
            ushort boardFieldsLeft = (ushort)(gameGridRows * gameGridCols);
            ushort boardFieldsTaken = 0;
            byte gameAmountOfMines = 30;
            bool gameIsDone = false;
            bool dead = false;

            // Også game states, men specifikt boardet og de forskellige værdier
            // Dette kunne simplificeres med et enkelt 2D array med struct eller class objekter some type.
            // Men for at holde mig inde for restriktionerne og kun bruge hvad vi har været igennem, så er dette opdelt i 3, med samme størrelser.

            // GridType bruger min enum GridType og fortæller om en position er None eller Mine. Kunne også have været lavet med bool, da jeg alligevel kun har brugt 2 mulige værdier her.
            GridType[,] gridArrayBoard = new GridType[gameGridRows, gameGridCols];
            /// Bool 2D array der fortæller om positionen er true (om positionen er synlig) eller om den er false (usynlig). Modsat her, der kunne jeg også have brugt enum.
            bool[,] gridVisible = new bool[gameGridRows, gameGridCols];
            // Byte 2D array hvor summen af nærliggende miner ligges som værdi i positionen. Byte bruges da der maksimalt ville kunne være 8 miner rundt om en position.
            byte[,] gridValue = new byte[gameGridRows, gameGridCols];

            // Kalder funktion der sætter miner rundt tilfældigt på boardet (gridArrayBoard), hvor jeg sætter nogle argumenter ind der matcher funktionens krav.
            DistributeMinesRandomly(gridArrayBoard, gameAmountOfMines, gameGridRows, gameGridCols);
            // Den første tegning af Minesweeper board og grafikken.
            DrawMinesweeperBoard(gridArrayBoard, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);

            // Så længe bool gameIsDone er falsk og at bool dead også er falsk, så forsætter spillets core gameplay loop.
            while(!gameIsDone && !dead)
            {
                // Brugeren spørges om row og column (altså koordinat) og gemmes i en var, som automatisk er en tuple, fordi PromptUserForRowAndCol returner en tuple.
                // Tuple indeholder row og column. Jeg kunne have opdelt PromptUserForRowAndCol i to funktioner, hvor den ene spørger om row og den anden spørger om column
                // Og så ville jeg nok have holdt mig til restriktionerne. Men selvom det er et objekt der returneres så synes jeg det var smartere end at lave to funktioner.
                var userCoordinate = PromptUserForRowAndCol(gameGridRows, gameGridCols);
                // Kalder en funktion som returner om brugerens input og dermed position/felt allerede er synligt. Hvis true, så er positionen allerede blevet valgt. Gemmes i bool positionIsVisible.
                bool positionIsVisible = CheckIfPositionIsAlreadyVisible(gridVisible, userCoordinate);
                // Kalder funktion der returnerer om brugerens input og dermed position/felt er en mine. Hvis true, så er feltet en mine. Gemmes i bool positionIsAMine.
                bool positionIsAMine = CheckIfPositionIsMine(gridArrayBoard, userCoordinate.row, userCoordinate.col);

                // if statement; hvis positionen er usynlig og ikke er en mine, så kører vi koden indeni
                if (!positionIsVisible && !positionIsAMine)
                {
                    // Hjælpe funktion der sætter positionen til at være visible
                    SetGridPositionVisibility(gridVisible, true, userCoordinate.row, userCoordinate.col);
                    // Kalder funktion der tæller antallet af miner omkring brugerens valgte position. Antallet returneres og gemmes i numberOfMinesAroundPosition
                    byte numberOfMinesAroundPosition = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);

                    // Hjælpe funktion der sætter antallet af miner omkring brugerens valgte position, som værdi i positionen.
                    // Kunne sikkert have været simplificeret.
                    SetGridPositionValue(gridArrayBoard, gridValue, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                    
                    // Nu er et felt taget, derfor bliver der et mindre felt tilbage og antallet af felter øges med 1.
                    boardFieldsLeft--;
                    boardFieldsTaken++;
                    // Gentegn hele boardet og grafik med den nyeste "game state".
                    RedrawMinesweeperBoard(gridArrayBoard, userCoordinate, numberOfMinesAroundPosition, gridVisible, gridValue, gameGridRows, gameGridCols, positionIsAMine, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);
                }
                // hvis positionen i stedet er en mine, så kører koden indeni
                else if(positionIsAMine)
                {
                    // Game states opdateres
                    dead = true;
                    gameIsDone = true;
                    boardFieldsLeft--;
                    boardFieldsTaken++;
                    // Selvom spilleren har tabt, så vælger vi for god UX, at udregne mængden af omkringliggende miner alligevel, så vi kan redraw
                    byte numberOfMinesAroundPosition = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                    // Redraw af board med bombe på brugerens valgte position, samt redraw af UI
                    RedrawMinesweeperBoard(gridArrayBoard, userCoordinate, numberOfMinesAroundPosition, gridVisible, gridValue, gameGridRows, gameGridCols, positionIsAMine, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);
                    // Beskeder for god UX til at indikere at brugeren har tabt.
                    Console.WriteLine("You died!");
                    // Igen for god UX, så vælger vi at prompte for ReadKey for at give brugeren kontrollen over hvornår brugeren vil table til menuen
                    Console.WriteLine("Press any key to continue back to menu");
                    Console.ReadKey();
                }
                // Hvis ikke de andre conditions bliver opfyldt, så må det være fordi positionen er blevet brugt før.
                else
                {
                    Console.WriteLine("Please choose a position that hasn't been chosen before");
                }
                // Her defineres hvad "win condition" er for spillet og her tjekker vi aktivt for det.
                // Hvis antallet af tilbageværende brikker er samme som antallet af miner i spillet, samt at brugeren ikke er død - jamen så har brugeren vundet)
                if(boardFieldsLeft == gameAmountOfMines && dead == false)
                {
                    // Ændring af game state, så vi kan komme ud af spillet primære game loop (et while loop)
                    gameIsDone = true;
                    // Her sker det samme som oppe i nogle af de andre if statements ovenover. Vi udregner for at kunne redraw UIen for at give en god UX.
                    byte numberOfMinesAroundPosition = CheckSurroundingPositions(gridArrayBoard, userCoordinate.row, userCoordinate.col, gameGridRows, gameGridCols);
                    RedrawMinesweeperBoard(gridArrayBoard, userCoordinate, numberOfMinesAroundPosition, gridVisible, gridValue, gameGridRows, gameGridCols, positionIsAMine, boardFieldsLeft, boardFieldsTaken, gameAmountOfMines);
                    // Fortæller brugeren at brugeren har vundet
                    Console.WriteLine("You won! Congratulations");
                    // Igen for god UX, så vælger vi at prompte for ReadKey for at give brugeren kontrollen over hvornår brugeren vil table til menuen
                    Console.WriteLine("Press any key to continue back to menu");
                    Console.ReadKey();
                }
            }
        }

        // Funktion der distribuerer miner tilfældigt på boardet. Kaldes inde i Minesweeper()
        static void DistributeMinesRandomly(GridType[,] board, byte amountOfMines, byte maxRows, byte maxCols)
        {
            // Definerer random af classen Random
            Random random = new Random();
            // for loop der laver en ny position for hver mine der er bestemt at spillet skal have.
            for (int i = 0; i < amountOfMines; i++)
            {
                // While loopet her sikrer os, at en ny position laves, hvis positionen allerede har fået en mine.
                while(true)
                {
                    // laver random rows og cols
                    byte randomRow = (byte)random.Next(0, maxRows);
                    byte randomCol = (byte)random.Next(0, maxCols);

                    // tjekker om positionen allerede er en mine, hvis ikke, så kører koden indeni.
                    if(!CheckIfPositionIsMine(board, randomRow, randomCol))
                    {   
                        // Positionen sættes til at være en mine
                        board[randomRow,randomCol] = GridType.Mine;
                        break;
                    }

                }
            }
        }

        // Funktion der spørger brugeren om row og colum. Altså en position. Funktionen returnerer en tuple med row og col.
        // Set i bakspejlet, så burde jeg nok have lavet to funktioner, som hver enten returnerede en row eller en col - da dette teknisk set bryder restriktionen om objekter.
        static (byte row, byte col) PromptUserForRowAndCol(byte rows, byte cols)
        {
            // lokale variabler defineres
            byte userRowNumber;
            byte userColNumber;

            // While loop der bliver ved med at køre, så længe at brugeren ikke har skrevet et tal til row, som holder sig inden for boardets rammer.
            while(true)
            {
                Console.Write($"Row between 0-{(rows-1)}: ");
                // ReadLine gemmes i string userRowResponse
                string userRowResponse = Console.ReadLine();
                // Ligesom med menuen, så prøver vi at konvertere brugerens string input om til integer. Om det er lykkedes (sandt eller falsk), det gemmes i userRowResponseIsNumber
                bool userRowResponseIsNumber = byte.TryParse(userRowResponse, out userRowNumber);
                
                // Hvis konverteringen lykkedes og userRowResponseIsNumber er true, så køres koden indeni.
                if (userRowResponseIsNumber)
                {   
                    // Hvis tallet er inden for mængden af rows, så bryder vi ud af while loopet med break.
                    if (userRowNumber >= 0 && userRowNumber <= (rows-1))
                    {
                        break;
                    }
                    // ellers får brugeren besked og vi starter forfra i while loop
                    else
                    {
                        Console.WriteLine("Please stay within the number range");
                    }
                }
                // Hvis konverteringen ikke lykkedes, så meldes dette. While loop starter forfra
                else
                {
                    Console.WriteLine("Please input valid numbers");
                }
            }
            // While loop der bliver ved med at køre, så længe at brugeren ikke har skrevet et tal til col, som holder sig inden for boardets rammer.
            while (true)
            {
                Console.Write($"\nCol between 0-{(cols-1)}: ");
                // ReadLine gemmes i string userColResponse
                string userColResponse = Console.ReadLine();
                // Ligesom med menuen, så prøver vi at konvertere brugerens string input om til integer. Om det er lykkedes (sandt eller falsk), det gemmes i userColResponseIsNumber
                bool userColResponseIsNumber = byte.TryParse(userColResponse, out userColNumber);
                // Hvis konverteringen lykkedes og userColResponseIsNumber er true, så køres koden indeni.
                if (userColResponseIsNumber)
                {
                    // Hvis tallet er inden for mængden af columns, så bryder vi ud af while loopet med break.
                    if (userColNumber >= 0 && userColNumber <= (cols-1))
                    {
                        break;
                    }
                    // ellers får brugeren besked og vi starter forfra i while loop
                    else
                    {
                        Console.WriteLine("Please stay within the number range");
                    }
                }
                // Hvis konverteringen ikke lykkedes, så meldes dette. While loop starter forfra
                else
                {
                    Console.WriteLine("Please input valid numbers");
                }
            }
            // returnerer tuple af bytes, i stedet for individuelt row eller column. Som beskrevet længere over, 
            // så kunne dette ændres til at kun at returnere enten row eller column, og så have to funktioner i stedet.
            return (userRowNumber, userColNumber);
        }

        // Tegner vores UI og board
        static void DrawMinesweeperBoard(GridType[,] gridArrayBoard, ushort fieldsLeft, ushort fieldsTaken, byte amountOfMines)
        {
            // Sætter konsollens originale tekst farve og baggrundsfarve i variabler, så jeg nemt kan sætte farverne tilbage
            ConsoleColor originalConsoleBackgroundColor = Console.BackgroundColor;
            ConsoleColor originalConsoleForegroundColor = Console.ForegroundColor;
            
            // UI til at vise spillets progression
            Console.Write($"\n      Fields left: {fieldsLeft}       Fields taken: {fieldsTaken}       Mines: {amountOfMines}\n\n");

            // for loop der looper første dimension ud, som er rows
            for (int i = 0; i < gridArrayBoard.GetLength(0); i++)
            {
                Console.ForegroundColor = originalConsoleForegroundColor;
                // for at skabe tal i siderne, for at indikere hvilken row vi er på, så writes det ud.
                // for at gøre UIen mere konsistent, så er der forskel på antallet af mellemrum, hvis tallet er over 10. Egentligt bare hvis tallet er 2-cifret eller mere.
                if (i >= 10)
                {
                    Console.Write($" {i}   ");

                }
                // ellers hvis tallet ikke er 2-cifret eller mere
                else
                {
                    Console.Write($" {i}    ");
                }

                // Her laves boardets UI
                // Vi kører anden dimension ud, altså columns
                Console.ForegroundColor = ConsoleColor.Black;
                for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("[ ]");
                    Console.BackgroundColor = originalConsoleBackgroundColor;
                }
                // efter alle columns er loopet ud i en row, så laver vi en new line, så næste row kommer ud på siden egen row, visuelt.
                Console.Write("\n");
            }

            // for at lave den nedre talrække til koordinatsystemet, så looper i anden dimension ud igen
            Console.ForegroundColor = originalConsoleForegroundColor;
            Console.Write($"      ");
            for (int j = 0; j < gridArrayBoard.GetLength(1); j++)
            {
                // Hvis tallet er 2-cifret eller mere, så bruger vi 1 mindre whitespace
                if (j >= 10)
                {
                    Console.Write($"{j} ");
                }
                // Ellers hvis tallet ikke er 2-cifret, så tilføjer vi et ekstra whitespace.
                else
                {
                    Console.Write($" {j} ");
                }
            }
            // New line for at i UIen gøre plads til brugerens inputs på en ny linje. Dermed lidt adskillelse.
            Console.Write("\n");
        }


        static void SetGridPositionValue(GridType[,] board, byte[,] gridValue, byte row, byte col, byte maxRowSize, byte maxColSize)
        {
            // hjælpe funktion der bruger de input argumenter til at kalde en hjælpe-funktion til at udregne mængden af miner omkring en position og derefter
            // sætte værdien i positionen i gridValue 2D arrayet.
            gridValue[row, col] = CheckSurroundingPositions(board, row, col, maxRowSize, maxColSize);
        }

        static void SetGridPositionVisibility(bool[,] gridVisible, bool b, byte row, byte col)
        {
            // hjælpe funktion der bruger input argumenter til at sætte en bool værdi i en position i gridVisible 2D array.
            gridVisible[row, col] = b;
        }

        static void RedrawMinesweeperBoard(GridType[,] gridArrayBoard, (byte row, byte col) userCoordinate, byte positionNumber, bool[,] gridVisible, byte[,] gridValue, byte maxRowSize, byte maxColSize, bool positionIsAMine, ushort fieldsLeft, ushort fieldsTaken, byte amountOfMines)
        {
            ConsoleColor originalConsoleBackgroundColor = Console.BackgroundColor;
            ConsoleColor originalConsoleForegroundColor = Console.ForegroundColor;

            Console.Clear();

            Console.Write($"\n      Fields left: {fieldsLeft}       Fields taken: {fieldsTaken}       Mines: {amountOfMines}\n\n");

            // Alt det her, er det samme som sker i DrawMinesweeperBoard, med undtagelse af, at der inden for loopet nu også sat en position som brugeren har valgt.
            // Hvis der intet er i positionen, så står der "-"
            // Hvis der er en mine, så står der [B]
            // Hvis der er miner i nærheden, så sættes der et tal.
            for (int i = 0; i < gridArrayBoard.GetLength(0); i++)
            {
                // row talrække bliver loopet ud her, ligesom i DrawMinesweeperBoard. Så jeg gennemgår ikke mere.
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
                    // Her kører vi brugerens angivne position
                    if (i == userCoordinate.row && j == userCoordinate.col)
                    {
                        // hvis brugerens angivne position er en mine
                        if (positionIsAMine)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("[B]");
                            Console.BackgroundColor = originalConsoleBackgroundColor;
                        }
                        // hvis ikke brugerens angivne position er en mine
                        else
                        {
                            // Hvis værdien er 0, så sætter vi bare "-" inde i firkant
                            if (positionNumber == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write($"[-]");
                                Console.BackgroundColor = originalConsoleBackgroundColor;
                            }
                            // hvis værdien er andet end 0, så sætter vi værdien i firkanten.
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
                        // Vi sætter også tidligere positioner. Og hvis positionen er synlig, så:
                        if (gridVisible[i, j] == true)
                        {
                            // hvis værdien i den synlige position er 0, så sættes til "-" inde i en firkant
                            if (gridValue[i, j] == 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Write("[-]");
                                Console.BackgroundColor = originalConsoleBackgroundColor;
                            }
                            // hvis værdien i den synlige position er andet end 0, så sættes værdien inde i en firkant
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write($"[{gridValue[i, j]}]");
                                Console.BackgroundColor = originalConsoleBackgroundColor;

                            }
                        }
                        // alle ikke valgte felter, de vises ligesom i DrawMinesweeperBoard. Altså bare en firkant
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.Write("[ ]");
                            Console.BackgroundColor = originalConsoleBackgroundColor;    
                        }
                    }
                }
                // new line for god ordens skyld i grafikken
                Console.Write("\n");
                // tekst farve sættes tilbage til det originale
                Console.ForegroundColor = originalConsoleForegroundColor;
            }
            // talrækkerne i bunden loopes ud her, ligesom i DrawMinesweeperBoard
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
            // hjælpe funktion til at tjekke om position allerede er synlig (om den er true), eller om den er usynlig
            if(gridVisible[userCoordinate.row, userCoordinate.col])
            {
                return true;
            }
            return false;
        }

        static bool CheckIfPositionIsMine(GridType[,] gridArray, byte row, byte col)
        {
            // hjælpe funktion til at tjekke om en position indeholder en mine. hvis ja, så returneres true. Hvis ikke, så returneres false.
            if (gridArray[row, col] == GridType.Mine)
            {
                return true;
            }
            return false;
        }

        static bool IsInsideBounds(int row, int col, byte maxRows, byte maxCols)
        {
            // hjælpe funktion til at udregne om en position er inden for boardet.
            // returnerer sand eller falsk
            return row >= 0 && row < maxRows && col >= 0 && col < maxCols;
        }

        static byte CheckSurroundingPositions(GridType[,] gridArray, byte row, byte col, byte maxRowSize, byte maxColSize)
        {
            // variabel til at holde antallet af miner fundet i omkringliggende positioner
            byte countAmountOfMines = 0;

            // De retninger eller relative positioner som vi gerne vil tjekke i forhold til vores row og col som er kommet ind som argument
            int[,] directions = new int[,]
            {
                {-1, -1}, {-1, 0}, {-1, 1},  // ØVRE ROW
                { 0, -1},          { 0, 1},  // MIDT ROW
                { 1, -1}, { 1, 0}, { 1, 1}   // NEDRE ROW
            };

            // Vi kører første dimension ud i et loop, da første dimension indeholder mængden af positioner
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                // midlertidige row og column til check
                int newRow = row + directions[i, 0];
                int newCol = col + directions[i, 1];

                // check om positionen er inden for boardet - hvis den er, så kører koden indeni
                if (IsInsideBounds(newRow, newCol, maxRowSize, maxColSize))
                {

                    // hvis positionen er en mine, så tæller vi én op i countAmountOfMines
                    if (CheckIfPositionIsMine(gridArray, (byte)newRow, (byte)newCol))
                    {
                        countAmountOfMines++;
                    }
                }
            }
            return countAmountOfMines;
        }

    }
}
