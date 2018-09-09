using System;
using System.Collections.Generic;
using System.IO;

namespace Hm52
{
    /// <summary>
    /// Класс, реализующий игру
    /// </summary>
    public class Game
    {
        private int origRow;
        private List<string> field;
        private int origCol;

        public Game(string nameFile)
        {
            field = InputField(nameFile);
        }

        /// <summary>
        /// Загружает поле из файла
        /// </summary>
        /// <param name="nameFile"> Имя файла с полем</param>
        /// <returns> Поле игры</returns>
        public List<string> InputField(string nameFile)
        {
            var field = new List<string>();
            using (StreamReader sr = File.OpenText(nameFile))
            {
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    field.Add(temp);
                    Console.WriteLine(temp);
                }
            }
            return field;
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
            WriteSpace();
            Console.SetCursorPosition(--origCol, origRow);
        }

        /// <summary>
        /// Возвращает координаты курсора
        /// </summary>
        /// <returns> Координаты курсора</returns>
        public List<int> Cursor()
        {
            var result = new List<int> { Console.CursorLeft, Console.CursorTop };
            return result;
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
            WriteSpace();
            Console.SetCursorPosition(origCol + 1, origRow);
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
            WriteSpace();
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
            WriteSpace();
            Console.SetCursorPosition(origCol, origRow - 1);
        }

        private void WriteSpace()
        {

            Console.SetCursorPosition(origCol, origRow);
            Console.Write(' ');
        }
    }
}
