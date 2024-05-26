using Pac_man_refactoring_.interfaces;
using Pac_man_refactoring_.models;

namespace Pac_man_refactoring_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var gameBoardEntity = new GameBoardFields();
            BaseEntity[,] field = gameBoardEntity.CreateGameBoard(ConsoleSettings.CONSOLEWIDTH,
                                                                  ConsoleSettings.CONSOLRHEIGTH);
            var pacman = new PacMan(5, 5);
            field[5, 5] = pacman;

            var user = new UserConsole();
            user.ColorForPacman(pacman);
            var levelsParam = user.ChooseLevel();

            var wall = new Wall(0, 0);
            new Coin(0, 0).CreateandDrawCoins(50, field);
            new Ghost(0,0).CreateGhosts(levelsParam.Item1, field);
            new Helper(0, 0).CreateandDrawHelper(levelsParam.Item2, field);

            for (int k = 1; k < 60; k++)
            {
                wall.CreateWall(8, field);
            }
            wall.DrawWall(field);
            gameBoardEntity.CreateBoard(field);

            while(ConsoleSettings.GameContinue)
            {
                var curdirection = user.ReadMovement(pacman.Direction);
                pacman.Move(curdirection, field);
                Ghost.RunGhosts(field);
                Thread.Sleep(100);
            }
        }
    }
}
