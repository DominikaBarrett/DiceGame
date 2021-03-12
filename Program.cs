using System;
using static System.Console;


namespace DiceGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DiceGameClass myGame = new DiceGameClass();
            myGame.Start();
        }
    }
}