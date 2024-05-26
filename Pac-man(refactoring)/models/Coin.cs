using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man_refactoring_.models
{
    public class Coin : BaseEntity
    {
        public static int CountCoins;
        public Coin(int x, int y) : base(x, y)
        {
            Color = ConsoleColor.Yellow;
        }

        public void CreateandDrawCoins(int count, BaseEntity[,] field)
        {
            for (int i = 0; i < count; i++)
            {
                var coin = GenerateEntity(field, (x,y) => new Coin(x,y));
                Draw(coin.X, coin.Y, Color);
                CountCoins++;
            }
        }

        public override bool IsEmpty()
        {
            return false;
        }
    }
}
