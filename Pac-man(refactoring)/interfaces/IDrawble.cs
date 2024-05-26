using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man_refactoring_.interfaces
{
    public interface IDrawble
    {
        public void Draw(int x, int y, ConsoleColor color);
        public void Clear(int x, int y);
    }
}
