using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightApplication
{
    public class Game
    {
        private string user;
        private string comp;
        private string field;
        public Game(string user)
        {
            this.user = user;
            comp = (user == "x") ? "o" : "x";
            field = "zzzzzzzzz";
        }

        public void InputElement(int index)
        {
            field = field.Substring(0,index) + user + field.Substring(index + 1);
        }

        public void Reset()
        {
            user = "";
            comp = "";
            field = "zzzzzzzzz";
        }

        public int InputComp()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 9);
            while (field[result -1] != 'z')
            {
                result = rnd.Next(1, 9);
            }
            field = field.Substring(0, result - 1) + comp + field.Substring(result);
            return result;
        }

        public bool IsUserWin()
        {
            string temp = (user == "x") ? "xxx" : "ooo";
            bool result = false;
            for (int i = 0; i < 3; i++)
            {
                string tempStr = field.Substring(i*3, 3);
                if (tempStr == temp)
                {
                    result = true;
                }
            }
            for (int i = 0; i <3; i++)
            {
                string tempStr = field.Substring(i,1) + field.Substring(i + 3, 1) + field.Substring(i + 6, 1);
                if(tempStr == temp)
                {
                    result = true;
                }
            }
            string glDiag = field.Substring(0, 1) + field.Substring(4, 1) + field.Substring(8, 1);
            string pbDiag = field.Substring(2, 1) + field.Substring(4, 1) + field.Substring(6, 1);
            if (glDiag == temp || pbDiag == temp)
            {
                result = true;
            }
            return result;
        }

        public bool IsCompWin()
        {
            string temp = (user == "x") ? "ooo" : "xxx";
            bool result = false;
            for (int i = 0; i < 3; i++)
            {
                string tempStr = field.Substring(i * 3, 3);
                if (tempStr == temp)
                {
                    result = true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                string tempStr = field.Substring(i, 1) + field.Substring(i + 3, 1) + field.Substring(i + 6, 1);
                if (tempStr == temp)
                {
                    result = true;
                }
            }
            string glDiag = field.Substring(0, 1) + field.Substring(4, 1) + field.Substring(7, 1);
            string pbDiag = field.Substring(2, 1) + field.Substring(4, 1) + field.Substring(6, 1);
            if (glDiag == temp || pbDiag == temp)
            {
                result = true;
            }
            return result;
        }
    }
}
