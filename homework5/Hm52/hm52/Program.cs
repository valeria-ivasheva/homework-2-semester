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
            FileStream file = new FileStream("file.txt", FileMode.Open);
            List <string> field = new List<string>(); 
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                field.Add(str);
                Console.WriteLine(str);
            }
            reader.Close();

            var eventLoop = new EventLoop();
            var game = new Game(field);

            eventLoop.LeftHandler += game.OnLeft;
            eventLoop.RightHandler += game.OnRight;
            eventLoop.UpHandler += game.OnUp;
            eventLoop.DownHandler += game.OnDown;

            eventLoop.Run();
        }
    }
}
