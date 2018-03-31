using System;
using System.Collections.Generic;

namespace hm52
{
    /// <summary>
    /// Класс, реализующий игру
    /// </summary>
    public class Game
    {
        protected static int origRow;
        protected List<string> field;
        protected static int origCol;

        public Game(List<string> inputField)
        {
            field = inputField;
        }

        /// <summary>
        /// Проверяет свободна ли клетка для записи и записывает при истинном значении
        /// </summary>
        /// <param name="x"> Координата клетки по х</param>
        /// <param name="y"> Координата клетки по у</param>
        /// <returns> Возвращает true, если клетка свободна</returns>
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

        /// <summary>
        /// Переводит элемент на одну позицию влево, если это возможно
        /// </summary>
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

        /// <summary>
        /// Переводит элемент на одну позицию вправо, если это возможно
        /// </summary>
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

        /// <summary>
        /// Переводит элемент на одну позицию вниз, если это возможно
        /// </summary>
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

        /// <summary>
        /// Переводит элемент на одну позицию вверх, если это возможно
        /// </summary>
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
