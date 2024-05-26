using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pac_man_refactoring_.enums;

namespace Pac_man_refactoring_.models
{
    public class Ghost : MovebleEntity
    {
        public static List<Ghost> ghosts = new List<Ghost>();
        public Ghost(int x, int y) : base(x, y)
        {
            Color = ConsoleColor.Gray;
        }

        public override bool IsKilling()
        {
            return true;
        }

        public override bool IsEmpty()
        {
            return false;
        }

        private bool CanMove(Direction direction, BaseEntity[,] field)
        {
            var newCoordinates = SwitchDirection(direction, this);

            return field[newCoordinates.Item1, newCoordinates.Item2].IsEmpty();
        }

        public void Move(Direction direction, BaseEntity[,] field)
        {
            Clear(X, Y);
            while (!CanMove(direction, field))
            {
                int enumLength = Enum.GetValues(typeof(Direction)).Length;
                int randomIndex = random.Next(1, enumLength);
                direction = (Direction)randomIndex;
            }
            var newCoordinates = SwitchDirection(direction, this);
            Direction = direction;
            RewriteEntity(field, newCoordinates.Item1, newCoordinates.Item2, this);
            Draw(X, Y, Color);
        }

        public  void CreateGhosts(int quantity, BaseEntity[,] field)
        {
            var random = new Random();
            for (int i = 0; i < quantity; i++)
            {
                var ghost = GenerateEntity(field, (x, y) => new Ghost(x, y));
                ghosts.Add(ghost);
            }
        }
        public static void RunGhosts(BaseEntity[,] field)
        {
            foreach (var gost in ghosts)
            {
                gost.Move(gost.Direction, field);
            }
        }
    }
}
