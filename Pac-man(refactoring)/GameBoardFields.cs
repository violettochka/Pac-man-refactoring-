using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pac_man_refactoring_.interfaces;
using Pac_man_refactoring_.models;
using static System.Console;

namespace Pac_man_refactoring_
{
    public class GameBoardFields
    {
        public BaseEntity[,] CreateGameBoard(int width, int heigth)
        {
            BaseEntity[,] field = new BaseEntity[width, heigth];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < heigth; y++)
                {
                    field[x, y] = new BaseEntity(x,y);
                }
            }
            return field;
        }

        public void CreateBoard(BaseEntity[,] field)
        {
            CursorVisible = false;
            SetWindowSize(ConsoleSettings.CONSOLEWIDTH, ConsoleSettings.CONSOLRHEIGTH);

            for (int x = 0;x < field.GetLength(0); x++)
            {
                field[x, 0] = new Wall(x, 0);
                field[x, 0].Draw(x, 0, ConsoleColor.Red);

                field[x, ConsoleSettings.CONSOLRHEIGTH - 1] = new Wall(x, ConsoleSettings.CONSOLRHEIGTH -1);
                field[x, ConsoleSettings.CONSOLRHEIGTH - 1].Draw(x, ConsoleSettings.CONSOLRHEIGTH - 1, ConsoleColor.Red);
            }

            for(int y = 0; y < field.GetLength(1); y++)
            {
                field[0, y] = new Wall(0, y);
                field[0, y].Draw(0, y, ConsoleColor.Red);

                field[ConsoleSettings.CONSOLEWIDTH - 1, y] = new Wall(ConsoleSettings.CONSOLEWIDTH - 1, y);
                field[ConsoleSettings.CONSOLEWIDTH - 1, y].Draw(ConsoleSettings.CONSOLEWIDTH - 1, y, ConsoleColor.Red);
            }
        }
    }
}
