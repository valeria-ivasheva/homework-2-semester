using System;
using System.Collections.Generic;
using System.IO;

namespace Hm52
{
    /// <summary>
    /// Игра, в которой штучка ходит по лабиринту
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string nameFile = @"file.txt";
            if (!File.Exists(nameFile))
            {
                return;
            }
            
            var eventLoop = new EventLoop();
            var game = new Game(nameFile);

            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;
            Console.SetCursorPosition(1, 1);
            eventLoop.Run();
        }
    }
}
