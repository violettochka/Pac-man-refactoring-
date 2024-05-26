using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pac_man_refactoring_.enums;
using Pac_man_refactoring_.interfaces;

namespace Pac_man_refactoring_.models
{
    public class MovebleEntity : BaseEntity
    {
        private Dictionary<Direction, (int, int)> _directionOffsets = new Dictionary<Direction, (int, int)>
        {
            { Direction.Right, (1, 0) },
            { Direction.Left, (-1, 0) },
            { Direction.Down, (0, 1) },
            { Direction.Up, (0, -1) }
        };

        public MovebleEntity(int x, int y) : base(x, y)
        {
        }
        public (int, int) SwitchDirection(Direction direction, BaseEntity elem)
        {
            if (_directionOffsets.TryGetValue(direction, out var coordinates))
            {
                Clear(X, Y);
                int newX = X + coordinates.Item1;
                int newY = Y + coordinates.Item2;
                return (newX, newY);
            }
            
            return (elem.X, elem.Y);
        }

        public void RewriteEntity(BaseEntity[,] field, int x, int y, BaseEntity elem)
        {
            field[elem.X, elem.Y] = new BaseEntity(elem.X, elem.Y);
            elem.X = x;
            elem.Y = y;
            field[x, y] = elem;  
        }
    }
}
