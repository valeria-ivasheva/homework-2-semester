using Microsoft.VisualStudio.TestTools.UnitTesting;
using hm52;
using System;
using System.Collections.Generic;

namespace hm52.Tests
{
    [TestClass]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game(@"file.txt");
            Console.SetCursorPosition(1, 1);
        }

        private List<string> map = new List<string> { "########", "#@ #   #", "# ## # #" ,
            "#    # #", "###### #", "#      #", "########"};

        [TestMethod()]
        public void CorrectMap()
        {
            string temp = @"file.txt";
            var inputMap = game.InputField(temp);
            int i = 0;
            Assert.AreEqual(map.Count, inputMap.Count);
            foreach (string tempStr in map)
            {
                Assert.AreEqual(tempStr, inputMap[i]);
                i++;
            }
        }

        [TestMethod()]
        public void OnLeftTest()
        {
            Console.SetCursorPosition(2, 1);
            for (int i = 0; i < 2; i++)
            {
                game.OnLeft(this, EventArgs.Empty);
                var temp = game.Cursor();
                Assert.AreEqual(1, temp[0]);
                Assert.AreEqual(temp[1], 1);
            }
        }

        [TestMethod()]
        public void OnRightTest()
        {
            for (int i = 0; i < 2; i++)
            {
                game.OnRight(this, EventArgs.Empty);
                var temp = game.Cursor();
                Assert.AreEqual(2, temp[0]);
                Assert.AreEqual(temp[1], 1);
            }
        }

        [TestMethod()]
        public void OnUpTest()
        {
            Console.SetCursorPosition(1, 2);
            for (int i = 0; i < 2; i++)
            {
                game.OnUp(this, EventArgs.Empty);
                var temp = game.Cursor();
                Assert.AreEqual(1, temp[0]);
                Assert.AreEqual(temp[1], 1);
            }
        }

        [TestMethod()]
        public void OnDownTest()
        {
            Console.SetCursorPosition(1, 2);
            for (int i = 0; i < 2; i++)
            {
                game.OnDown(this, EventArgs.Empty);
                var temp = game.Cursor();
                Assert.AreEqual(1, temp[0]);
                Assert.AreEqual(temp[1], 3);
            }
        }
    }
}