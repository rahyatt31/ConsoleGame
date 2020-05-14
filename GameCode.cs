using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public class GameCode
    {
        string aIChoice;
        string userChoice;
        bool isGameActive = true;              // Created this bool so easily end the game when completing 5 rounds
        int rounds = 0;                        // Starting the round at 0, because we add 1, after the first round, to the roundTotal
        int maxRounds = 4;                     // We make this 4 instead of 5 rounds, because it does one more round after, which is where we conclude the winner
        int playerScore, aIScore = 0;          // Start both the user and computer at 0
        string spacing = "\n\n\n\n\n\n\n";     // Created this string as a shortcut for several \n

        Dictionary<string, int> choices = new Dictionary<string, int>       // Using a dictionary to easily assign values to the options
        {
            {"Rock", 1 },                                                   // Assigning a number to Rock
            {"Paper", 2 },                                                  // Assigning a number to Paper
            {"Scissors", 3 },                                               // Assigning a number to Scissors
        };

        public void Run()                                                   // Our three different screens
        {
            WelcomeScreen();                                                // Title / Welecome screen
            RunMenu();                                                      // Our Main Menu screen
            StartGame();                                                    // Our In-Game screen
        }

        public void WelcomeScreen()                                         // Method for our Welcome screen
        {
            Console.Clear();                                                // Clears everything out from previous page
            Console.ForegroundColor = ConsoleColor.DarkYellow;              // Changing the TITLE color to dark yellow
            Console.WriteLine(@"
                                      _____            _        _____                      
                                     |  __ \          | |      |  __ \                     
                                     | |__) |___   ___| | __   | |__) |_ _ _ __   ___ _ __ 
                                     |  _  // _ \ / __| |/ /   |  ___/ _` | '_ \ / _ \ '__|
                                     | | \ \ (_) | (__|   < _  | |  | (_| | |_) |  __/ | _ 
                                     |_|  \_\___/ \___|_|\_( ) |_|   \__,_| .__/ \___|_|( )
                                                           |/             | |           |/ 
                                                                          |_|              
                                              _____      _                        
                                             / ____|    (_)                       
                                            | (___   ___ _ ___ ___  ___  _ __ ___ 
                                             \___ \ / __| / __/ __|/ _ \| '__/ __|
                                             ____) | (__| \__ \__ \ (_) | |  \__ \
                                            |_____/ \___|_|___/___/\___/|_|  |___/
                                                     ");

            Console.ForegroundColor = ConsoleColor.White;                   // Changes the color back to white, otherwise everything would stay yellow
            Console.ReadKey();                                              // Forcing user to start game instead of jumping right in
        }

        private void RunMenu()                                              // Method for our Run Menu
        {
            Console.Clear();                                                // Clears everything at the start of the screen
            
            string startGame = "1. Start Game";                             // Creating our two options on our Run Menu
            string exit = "2. Exit";                                        // The options are to start the game or exit

            while (isGameActive == true)                                    // We created a while loop so easily end the game later on
            {   
                Console.WriteLine(spacing +                                 // These three lines are all about spacing our Run Menu items
                    startGame.PadLeft(59) + "\n" +                          // in the center of our Console App, lots of trial and error
                    exit.PadLeft(53));

                string goodBye = "Goodbye!";
                string selection = Console.ReadLine();                      // Creating this string for our switch cases, also have it equal
                                                                            // to a ReadLine so the user has to select an option to proceed
                switch (selection)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        isGameActive = false;                               // Circling back to line 63; setting this to false easily ends the
                        Console.WriteLine(goodBye.PadLeft(59));             // Console App while also saying goodbye, with padding
                        Environment.Exit(0);                                // This line of code closes the console application and avoids crash
                        break;
                    default:                                                // Important to have this default; since we have it set to Run Menu
                        RunMenu();                                          // it basically restarts this page. Without it, if we pressed anything
                        break;                                              // besides our two cases, we would continue to print those two cases,
                }                                                           // which looks sloppy and broken
            }
        }

        private void StartGame()                                            // Our Method for our In-Game screen
        {
            Console.Clear();                                                // Clears Screen
            Console.WriteLine("Would you like Rock, Paper, or Scissors?");  // Asks question for both computer and user
            
            aIChoice = AISelection(choices);                                // Computer randomly chooses its option
            userChoice = UserSelection();                                   // User makes its selection
            
            Console.WriteLine(userChoice.PadLeft(59));                      // Writes down users' choice
            Comparison(userChoice, aIChoice);                               // Compares both answers and determins winner of round
            Console.ReadKey();
        }
                                                                            // Created 3 Methods as shortcuts for our code, this cleaned up
        private void TieRound()                                             // our if/else statements below in our COMPARISON Method
        {
            Console.ForegroundColor = ConsoleColor.Green;                   // Changes the color to green
            
            string tie = "Tie";                                             // Created this string to make it easy to center our text
            Console.WriteLine(tie.PadLeft(59));
   
            string tieTotal = $"Total {rounds}";                            // Created this string to make it easy to center our text
            Console.WriteLine(tieTotal.PadLeft(59));
            
            Console.ForegroundColor = ConsoleColor.White;                   // Changes the color back to white

            Console.ReadKey();
            RunMenu();                                                      // Sends us back to our Run Menu page
        }

        private void LoseRound()
        {
            Console.ForegroundColor = ConsoleColor.Red;                     // Changes the color to red
           
            string lose = "You Lose";
            Console.WriteLine(lose.PadLeft(59));

            rounds++;                                                       // Adds to our round and score total, we aren't counting "TIES"
            aIScore++;                                                      // as rounds, which is why we don't have these ines in that Method
            
            string loseTotal = $"Total {rounds}";
            Console.WriteLine(loseTotal.PadLeft(59));
            
            Console.ForegroundColor = ConsoleColor.White;                   // Changes the color back to white

            Console.ReadKey();
            RunMenu();                                                      // Sends us back to our Run Menu page
        }

        private void WinRound()
        {
            Console.ForegroundColor = ConsoleColor.Blue;                     // Changes colors to blue

            string win = "You Win";
            Console.WriteLine(win.PadLeft(59));
            
            rounds++;
            playerScore++;
            
            string winTotal = $"Total {rounds}";
            Console.WriteLine(winTotal.PadLeft(59));
            
            Console.ForegroundColor = ConsoleColor.White;                   // Changes colors back to white

            Console.ReadKey();
            RunMenu();                                                      // Sends us back to our Run Menu page
        }

        private string PaperPic()
        { 
            string paperPic = @"
                                                ----------------
		                                |	       |
		                                |  Paper...    |
		                                |	       |
		                                | ~~~~~~~~~~~~ |
		                                | ~~~~~~~~~~   |
		                                | ~~~~~~~~     |
		                                |	       |
		                                ----------------";
            paperPic.PadLeft(25);
            return paperPic;
        }

        private string RockPic()
        {
            string rockPic = @"
                                            ----------------------
		                          /                        \
                                         |      ^             ^     |
		                         |      |             |     |
		                         |      |             |     |
		                         |                          |
		                         |                          |
		                         |                          |
		                         |   <------------------- > |
		                         |            ----          |
		                         |                          |
		                         |                          |
		                         \                          /
			                    ----------------------";

            rockPic.PadLeft(25);
            return rockPic;
        }

        private string ScissorsPic()
        {
            string scissorsPic = "\t\t\t" + @"----------------------
		      /                        \
                     |    ------------------    |
		     |   | 		     |  |                      ^
		     |   |  	             |  |                    /  /
		     |   |                   |  |                   /  /
		     |   |                   |  |                  /  / 
		     |   |                   |  |                 /  /             
		     |   |                   |  |                /  /
		     |   |                   |  |               /  /
		     |   |                   |  |              /  /
		     |    ------------------    |             /  /
		     \                          /            /  /
			----------------------              /  /
							/---\ /
						       |     |
			----------------------          \---/\
		      /                        \	   \  \
                     |    ------------------    |           \  \
		     |   | 		     |  |            \  \
		     |   |  	             |  |	      \	 \
		     |   |                   |  |	       \  \
		     |   |                   |  |		\  \ 
		     |   |                   |  |		 \  \ 
		     |   |                   |  |		  \  \
		     |   |                   |  |		   \  \
		     |   |                   |  |		    \ /
		     |    ------------------    |
		     \                          /
			----------------------";

            scissorsPic.PadLeft(25);
            return scissorsPic;
        }
        
        private void Comparison(string user, string aI)
        {
            ScoreTable(playerScore, aIScore);                               // The Comparison Method is where all the outcomes are decided
                                                                            // We made Methods, see line 99, to simplify the if/else statements
            if (rounds != maxRounds)                                        // We also include the three pictures to show when that option is
            {                                                               // deemed the winner regardless if by user or computer
                if (user == aI)
                {
                    TieRound();
                }
                else if (user == "Rock" && aI == "Paper")
                {
                    Console.WriteLine(PaperPic()); 
                    LoseRound();
                }
                else if (user == "Rock" && aI == "Scissors")
                {
                    Console.WriteLine(RockPic());
                    WinRound();
                }
                else if (user == "Paper" && aI == "Scissors")
                {
                    Console.WriteLine(ScissorsPic());
                    LoseRound();
                }
                else if (user == "Paper" && aI == "Rock")
                {
                    Console.WriteLine(PaperPic());
                    WinRound();
                }
                else if (user == "Scissors" && aI == "Rock")
                {
                    Console.WriteLine(RockPic());
                    LoseRound();
                }
                else if (user == "Scissors" && aI == "Paper")
                {
                    Console.WriteLine(ScissorsPic());
                    WinRound();
                }
            }
        }

        private string AISelection(Dictionary<string, int> aIChoice)
        {                                                                   // We gave the AISelection Method a randomized selection
            Console.Clear();
            Random rand = new Random();                                     // Created "rand" as a new random number generator
            int num = rand.Next(1, 4);                                      // Declared "num" as a random integer between 1-3

            foreach (var data in aIChoice)
            {
                if (data.Value == num)
                {
                    return data.Key;
                }
            }
            return null;                                                    // Make sure to return null incase something besides 1,2,3 is choosen
        }

        public string UserSelection()
        {
            Console.Clear();
            
            string choice;
            string chooseBetween = "Choose Between\n";
            string rock = "1. Rock\n";
            string paper = "2. Paper\n";
            string scissors = "3. Scissors\n";

            Console.WriteLine(spacing + chooseBetween.PadLeft(59) + rock.PadLeft(59) + paper.PadLeft(59) + scissors.PadLeft(59));

            string userSelection = Console.ReadLine();

            switch (userSelection)                                          // Used a switch to give the user
            {
                case "1":
                    choice = "Rock";
                    return choice;
                case "2":
                    choice = "Paper";
                    return choice;
                case "3":
                    choice = "Scissors";
                    return choice;
                default:
                    RunMenu();
                    break;
            }
            return null;
        }

        private void ScoreTable(int player, int aI)
        {
            if (rounds == maxRounds)                                        // We already declared maxRounds at the top
            {                                                               // We are stating that once we reach our maxRounds, to go ahead
                if (playerScore > aIScore)                                  // with our if / else statement
                {
                    string playerWin = "Player Wins";

                    Console.WriteLine(playerWin.PadLeft(59));
                    Console.ReadKey();

                    isGameActive = false;                                   // Essesntially stops the game from continuing
                    Environment.Exit(0);                                    // This line of code closes the console application and avoids crash
                }
                else
                {
                    string playerLose = "Player Loses";

                    Console.WriteLine(playerLose.PadLeft(59));
                    Console.ReadKey();

                    isGameActive = false;                                   // Essesntially stops the game from continuing
                    Environment.Exit(0);                                    // This line of code closes the console application and avoids crash
                }
            }
        }
    }
}