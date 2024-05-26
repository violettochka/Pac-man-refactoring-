using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man_refactoring_.models
{
    public class Wall : BaseEntity
    {
        public Wall(int x, int y) : base(x, y)
        {
            Color = ConsoleColor.Red;
        }

        public override bool IsKilling()
        {
            return true;
        }

        public override bool IsEmpty()
        {
            return false;
        }

        public void CreateWall(int size, BaseEntity[,] field)
        {
            var block = new List<Wall>();
            var direction = random.Next(1, 3);

            int randomX;
            int randomY;
            do
            {
                randomX = random.Next(2, (ConsoleSettings.CONSOLEWIDTH - size) / 2) * 2;
                randomY = random.Next(2, (ConsoleSettings.CONSOLRHEIGTH - size) / 2) * 2;
            } while (!field[randomX, randomY].IsEmpty());

            block.Add(new Wall(randomX, randomY));
            field[randomX, randomY] = new Wall(randomX, randomY);
            for (int i = 1; i < size; i++)
            {
                var currentwall = block.LastOrDefault();
                if(direction == 1)
                {
                    if (field[currentwall.X, currentwall.Y + 2] is Wall)
                    {
                        break;
                    }
                    else
                    {
                        block.Add(new Wall(currentwall.X, currentwall.Y + 1));
                        field[currentwall.X, (currentwall.Y + 1)] = new Wall(currentwall.X, (currentwall.Y + 1)); ;
                    }
                }
                else if(direction == 2)
                {
                    if (field[currentwall.X + 2, currentwall.Y] is Wall)
                    {
                        break;
                    }
                    else
                    {
                        block.Add(new Wall(currentwall.X + 1, currentwall.Y));
                        field[currentwall.X + 1, currentwall.Y] = new Wall(currentwall.X + 1, currentwall.Y);
                    }
                }
            }
        }

        public void DrawWall(BaseEntity[,] field)
        {
            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (field[x, y] is Wall)
                    {
                        field[x, y].Draw(x, y, Color);
                    }
                }
            }
        }
    }
}
