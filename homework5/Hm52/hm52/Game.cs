using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hm52
{
    public class Game
    {
        protected static int origRow;
        protected List<string> field;
        protected static int origCol;

        public Game(List<string> inputField)
        {
            field = inputField;
        }

        private bool WriteAt(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            char smb = field[y][x];
            if (smb == '#')
            {
                return false;
            }
            Console.SetCursorPosition(Console.CursorLeft--, Console.CursorTop);
            Console.Write('@');
            return true;
        }

        public void OnLeft(object sender, EventArgs args)
        {
            origCol = Console.CursorLeft;
            origRow = Console.CursorTop;
            if (!WriteAt(origCol - 1, origRow))
            {
                Console.SetCursorPosition(origCol, origRow);
                return;
            }
            Console.Write(' ');
            Console.SetCursorPosition(--origCol, origRow);
        }

        public void OnRight(object sender, EventArgs args)
        {
            origCol = Console.CursorLeft;
            origRow = Console.CursorTop;
            if (!WriteAt(origCol + 1, origRow))
            {
                Console.SetCursorPosition(origCol, origRow);
                return;
            }
            Console.SetCursorPosition(origCol, origRow);
            Console.Write(' ');
        }

        public void OnDown(object sender, EventArgs args)
        {
            origCol = Console.CursorLeft;
            origRow = Console.CursorTop;
            if (!WriteAt(origCol, origRow + 1))
            {
                Console.SetCursorPosition(origCol, origRow);
                return;
            }
            Console.SetCursorPosition(origCol, origRow);
            Console.Write(' ');
            Console.SetCursorPosition(origCol, origRow + 1);
        }

        public void OnUp(object sender, EventArgs args)
        {
            origCol = Console.CursorLeft;
            origRow = Console.CursorTop;
            if (!WriteAt(origCol, origRow - 1))
            {
                Console.SetCursorPosition(origCol, origRow);
                return;
            }
            Console.SetCursorPosition(origCol, origRow);
            Console.Write(' ');
            Console.SetCursorPosition(origCol, origRow - 1);
        }
    }
}
