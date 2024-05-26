using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Pac_man_refactoring_.enums;
using Pac_man_refactoring_.models;
using static System.Console;

namespace Pac_man_refactoring_
{
    public class UserConsole
    {
        public Direction ReadMovement(Direction currentDirrection)
        {
            if (!KeyAvailable)
            {
                return currentDirrection;
            }
            ConsoleKey key = ReadKey(true).Key;
            currentDirrection = key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => currentDirrection
            };

            return currentDirrection;
        }

        public void ColorForPacman(PacMan pacman)
        {
            WriteLine("Before starting the game, " +
                      "select the desired color of the player" +
                      "(white, blue, green)");

            WriteLine("By default, the player's color " +
                      "will be selected automatically"); 

            var color = ReadLine();
            Clear();

            var availibleColors = new Dictionary<string, ConsoleColor>()
            {
                { "white" , ConsoleColor.White},
                { "pink" , ConsoleColor.Magenta},
                { "blue" , ConsoleColor.Cyan},
            };

            if (availibleColors.TryGetValue(color, out var matchColor))
            {
                pacman.SetColor(matchColor);

                return;
            }
            pacman.SetColor();
        }

        public (int, int) ChooseLevel()
        {
            var availibleLevels = new Dictionary<int, (int, int)>()
            {
                { 1 , (3, 1) },
                { 2 , (5, 2) },
                { 3 , (6, 2) },
            };
            WriteLine("It is also necessary to choose the difficulty of the game." +
                              " Write the desired level of the game (a number from 1 to 3)");
            var input = ReadLine();
            var isValid = int.TryParse(input, out var number);
            while(!isValid || number < 1 || number > 3)
            {
                WriteLine("Please, enter a valid data");
                input = ReadLine();
                isValid = int.TryParse(input, out number);
                Clear();
            }
            if (availibleLevels.TryGetValue(number, out var matchLevel))
            {
                return matchLevel;
            }
            return availibleLevels[1];
        }
    }
}
