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
    public class BaseEntity : IDrawble
    {
        public Random random;
        public delegate T EntityFactory<T>(int x, int y) where T : BaseEntity;
        public Direction Direction { get; set; }
        public const char PIXELCHAR = '█';
        public ConsoleColor Color { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }
        public BaseEntity(int x, int y)
        {
            X= x;
            Y= y;
            Color = ConsoleColor.White;
            random = new Random();
        }

        public virtual bool IsKilling()
        {
            return false;
        }

        public virtual bool IsEmpty()
        {
            return true;
        }

        public virtual void Draw(int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(PIXELCHAR);
        }

        public virtual void Clear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public T GenerateEntity<T>(BaseEntity[,] field, EntityFactory<T> factory) where T : BaseEntity
        {
            int randomX;
            int randomY;
            do
            {
                randomX = random.Next(1, ConsoleSettings.CONSOLEWIDTH - 1);
                randomY = random.Next(1, ConsoleSettings.CONSOLRHEIGTH - 1);
            } while (!field[randomX, randomY].IsEmpty());
            var entity = factory(randomX, randomY);
            field[randomX, randomY] = factory(randomX, randomY);
            return entity;
        }
    }
}
