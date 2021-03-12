using System;
using static System.Console;

namespace DiceGame
{
    public class DiceGameClass
    {
        private string GameName;
        private Random RandomGenerator;
        private int Score;

        private string UnknownGraphick = @"
    +---------+
    | ?     ? |
    | ?  ?  ? |
    | ?     ? |
    +---------+";
        private string RollOne = @"
    +---------+
    |         |
    |    o    |
    |         |
    +---------+";
        private string RollTwo = @"
    +---------+
    | o       |
    |         |
    |       o |
    +---------+";
        private string RollThree = @"
    +---------+
    | o       |
    |    o    |
    |       o |
    +---------+";
        private string RollFour = @"
    +---------+
    | o     o |
    |         |
    | o     o |
    +---------+";
        private string RollFive = @"
    +---------+
    | o     o |
    |    o    |
    | o     o |
    +---------++";
        private string RollSix = @"
    +---------+
    | o     o |
    | o     o |
    | o     o |
    +---------+";
    

        public DiceGameClass()
        {
            //initialize logic of teh game
            Score = 0;
            GameName = "Dice Game";
            RandomGenerator = new Random();
        }

        public void Start()
        {
            
            Clear();
            // method that starts the game running
            Title = GameName;
            WriteLine($"======{GameName}");
            WriteLine(UnknownGraphick);
            WriteLine(@"
██████╗ ██╗ ██████╗███████╗     ██████╗  █████╗ ███╗   ███╗███████╗
██╔══██╗██║██╔════╝██╔════╝    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
██║  ██║██║██║     █████╗      ██║  ███╗███████║██╔████╔██║█████╗  
██║  ██║██║██║     ██╔══╝      ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
██████╔╝██║╚██████╗███████╗    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
╚═════╝ ╚═╝ ╚═════╝╚══════╝     ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
                                                                   
");
            WriteLine("\nLets trow a dice...");
            WriteLine("\nInstructions:");
            WriteLine("\t>Try to guess each time if it is low or high.");
            WriteLine("\t>If you guess right you get a point.");
            WriteLine("\nReady to play? (yes/no) ");

            string playResponse = ReadLine().Trim().ToLower();
            if (playResponse == "yes")
            {
                WriteLine("Fantastic -lets play!");
                PlayRound();
            }
            else
            {
                WriteLine(" Okey, maybe some other time...");
            }

            WriteLine("press any key to exit ");
            ReadKey();
        }

        private void PlayRound()
        {
            // ?method tha runs one of rolling and guessing
            Clear();
            WriteLine("Iam about to roll..");
            WriteLine(UnknownGraphick);
            WriteLine("Is it going to be low(1,2,3) or high (4,5,6)");

            string response = ReadLine().Trim().ToLower();

            int roll = RandomGenerator.Next(1, 7);
            WriteLine();
            ForegroundColor = ConsoleColor.Blue;
            switch (roll)
            {
                case 1:
                    WriteLine(RollOne);
                    break;
                case 2:
                    WriteLine(RollTwo);
                    break;
                case 3:
                    WriteLine(RollThree);
                    break;
                case 4:
                    WriteLine(RollFour);
                    break;
                case 5:
                    WriteLine(RollFive);
                    break;
                case 6:
                    WriteLine(RollSix);
                    break;
                default:
                    WriteLine("oeps...somthing went wrong");
                    break;

            }
            WriteLine($" The roll was {roll}.");
            if (response == "high")
            {
                WriteLine("you guessed high...");
                if (roll <= 3)
                {
                    Lose();
                }
                else
                {
                    Win();
                }
            }
            else if(response =="low")
            {
                WriteLine("you guessed low...");
                if (roll >= 3)
                {
                    Lose();
                }
                else
                {
                    Win();
                }
            }else
            {
                WriteLine($"you guessed  {response}. That s not valid. Try again with 'high' or 'low'.");
            }
            AskToPlayAgain();
        }
        

        private void Win()
        {
            // method that increments the score and lets the player to know who won
            Score += 1;
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Congratulation You won ");
            WriteLine($"Score: {Score}");
        }

        private void Lose()
        {
            // method lets player to know they lost
            ForegroundColor = ConsoleColor.Red;
            WriteLine(" You lost.... ");
            WriteLine($"Score: {Score}");
        }

        private void AskToPlayAgain()
        {
            // method that ask teh player if tehy want to play again
            WriteLine("Would you like to play again? (yes/no)");
            string playResponse = ReadLine().Trim().ToLower();
            if (playResponse == "yes")
            {
                PlayRound();
            }
            else
            {
                WriteLine("Had enough? '\n'-Ok. See you later");
            }
        }
        
    }
}