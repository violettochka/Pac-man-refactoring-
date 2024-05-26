using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pac_man_refactoring_.enums;
using Pac_man_refactoring_.interfaces;

namespace Pac_man_refactoring_.models
{
    public class PacMan : MovebleEntity
    {
        public int CountCoins = 0;
        public PacMan(int x, int y) : base(x, y)
        {
        }
        
        public override bool IsEmpty()
        {
            return false;
        }

        public void SetColor(ConsoleColor color = ConsoleColor.Blue)
        {
            Color = color;
        }

        public void Move(Direction direction, BaseEntity[,] field)
        {
            Clear(X, Y);
            Direction = direction;
            var newCoordinates = SwitchDirection(direction, this);
            KillingPacman(newCoordinates.Item1, newCoordinates.Item2, field);
            TakeHelper(newCoordinates.Item1, newCoordinates.Item2, field);
            TakeCoin(newCoordinates.Item1, newCoordinates.Item2, field);
            RewriteEntity(field, newCoordinates.Item1, newCoordinates.Item2, this);
            Draw(X, Y, Color);
        }

        public void TakeHelper(int x, int y, BaseEntity[,] field)
        {
            if (field[x, y] is Helper)
            {
                var ghost = Ghost.ghosts.FirstOrDefault();
                Ghost.ghosts.Remove(ghost);
                Clear(ghost.X, ghost.Y);
                field[ghost.X, ghost.Y] = new BaseEntity(ghost.X, ghost.Y);
            }
        }

        private void TakeCoin(int x, int y, BaseEntity[,] field)
        {
            if (field[x, y] is Coin)
            {
                field[x, y] = new BaseEntity(x, y);
                CountCoins++;
            }
            if(CountCoins == Coin.CountCoins)
            {
                ConsoleSettings.WinGame = true;
                ConsoleSettings.GameOver(this);
                ConsoleSettings.GameContinue = false;
            }
        }

        private void KillingPacman(int x, int y, BaseEntity[,] field)
        {
            if (field[x, y].IsKilling())
            {
                ConsoleSettings.GameOver(this);
                ConsoleSettings.GameContinue = false;
            }
        }
    }
}
