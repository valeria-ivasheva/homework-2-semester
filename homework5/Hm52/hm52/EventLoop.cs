using System;

namespace Hm52
{
    /// <summary>
    /// Класса, генерирующий события по нажатию на клавиши управления курсором
    /// </summary>
    public class EventLoop
    {
        public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public event EventHandler<EventArgs> RightHandler = (sender, args) => { };
        public event EventHandler<EventArgs> DownHandler = (sender, args) => { };
        public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

        /// <summary>
        /// Игра начинается
        /// </summary>
        public void Run()
        {
            bool end = false;
            while (!end)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.Tab:
                        end = true;
                        break;
                }
            }
        }
    }
}
