using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man_refactoring_.models
{
    public class Helper : BaseEntity
    {
        public Helper(int x, int y) : base(x, y)
        {
            Color = ConsoleColor.Green;
        }

        public override bool IsEmpty()
        {
            return false;
        }
        public void CreateandDrawHelper(int count, BaseEntity[,] field)
        {
            for (int i = 0; i < count; i++)
            {
                var helper = GenerateEntity(field, (x, y) => new Helper(x, y));
                Draw(helper.X, helper.Y, Color);
            }
        }
    }
}
