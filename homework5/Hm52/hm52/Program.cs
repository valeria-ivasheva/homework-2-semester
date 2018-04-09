using System;
using System.Collections.Generic;
using System.IO;

namespace hm52
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

            var eventLoop = new EventLoop();
            var game = new Game(field);

            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;
            Console.SetCursorPosition(1, 1);
            eventLoop.Run();
        }
    }
}
