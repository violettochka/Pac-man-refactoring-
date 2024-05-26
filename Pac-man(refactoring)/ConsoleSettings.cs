using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pac_man_refactoring_.models;

namespace Pac_man_refactoring_
{
    public static class ConsoleSettings
    {
        public const int CONSOLEWIDTH = 80;
        public const int CONSOLRHEIGTH = 60;
        public static bool GameContinue = true;
        public static bool WinGame = false;

        public static void GameOver(PacMan pacman)
        {
            Console.Clear();

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2;
            if(WinGame)
            {
                Console.SetCursorPosition(centerX - ("You win, your points: ".Length +
                                          pacman.CountCoins.ToString().Length) / 2, centerY);
                Console.Write($"You win, your points: {pacman.CountCoins}");
            }
            else
            {
                Console.SetCursorPosition(centerX - ("You lost, your points: ".Length + 
                                          pacman.CountCoins.ToString().Length) / 2, centerY);
                Console.Write($"You lost, your points: {pacman.CountCoins}");
            }
            Console.ReadLine();
        }
    }
}
