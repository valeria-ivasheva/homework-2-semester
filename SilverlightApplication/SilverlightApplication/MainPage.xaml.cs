using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;	
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SilverlightApplication
{
    public partial class MainPage : UserControl
    {
        private string user;
        private string comp;
        private Game game;
        private int queue;
        public bool start;

        public MainPage()
        {
            InitializeComponent();
            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri("lolX.png", UriKind.RelativeOrAbsolute);
            img.Source = bitmapImage;
            buttonO.Content = img;
            Image imgX = new Image();
            BitmapImage bitmapImageX = new BitmapImage();
            bitmapImageX.UriSource = new Uri("lolO.png", UriKind.RelativeOrAbsolute);
            imgX.Source = bitmapImageX;
            buttonX.Content = imgX;
        }

        private void buttonStartClick(object sender, RoutedEventArgs e)
        {
            Storyboard1.Begin();
            Reset();
            start = true;
            var result = MessageBox.Show("Вы будете играть крестиками?", "Выберете", MessageBoxButton.OKCancel);
            user = (result == MessageBoxResult.OK) ? "x" : "o";
            comp = (user == "x") ? "o" : "x";
            game = new Game(user);
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            if(!start)
            {
                MessageBox.Show("Нажмите на старт", "Пожалуйста", MessageBoxButton.OK);
                return;
            }
            string temp = (sender as Button).Name;
            int number;
            int.TryParse(temp.Substring(temp.Length - 1), out number);
            game.InputElement(number - 1);
            if (game.IsUserWin())
            {
                MessageBox.Show("Еееее, вы выиграли", "Поздравляем", MessageBoxButton.OK);
                Reset();
                game.Reset();
                return;
            }
            queue++;
            PutImage(sender, true);
            if (queue == 9)
            {
                MessageBox.Show("У нас ничья", "Поздравляем", MessageBoxButton.OK);
                Reset();
                game.Reset();
                return;
            }
            number = game.InputComp();
            PutImageComp(number);
            queue++;
            if (game.IsCompWin())
            {
                MessageBox.Show("Вы проиграли :(", "Поздравляем", MessageBoxButton.OK);
                Reset();
                game.Reset();
                return;
            }
        }

        private void Reset()
        {
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
            button9.Content = "";
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
            user = "";
            queue = 0;
            start = false;
            comp = "";
        }

        private void PutImage(object sender, bool isUser)
        {

            Image img = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri("lolX.png", UriKind.RelativeOrAbsolute);
            img.Source = bitmapImage;
            Image imgX = new Image();
            BitmapImage bitmapImageX = new BitmapImage();
            bitmapImageX.UriSource = new Uri("lolO.png", UriKind.RelativeOrAbsolute);
            imgX.Source = bitmapImageX;
            if ((isUser && user == "x") || (!isUser && user == "o"))
            {
                (sender as Button).Content = imgX;
            }
            if ((isUser && user == "o") || (!isUser && user =="x"))
            {
                (sender as Button).Content = img;
            }
            (sender as Button).IsEnabled = false;
        }

        private void PutImageComp(int index)
        {
            switch (index)
            {
                case 1:
                    {
                        PutImage(button1, false);
                        break;
                    }
                case 2:
                    {
                        PutImage(button2, false);
                        break;
                    }
                case 3:
                    {
                        PutImage(button3, false);
                        break;
                    }
                case 4:
                    {
                        PutImage(button4, false);
                        break;
                    }
                case 5:
                    {
                        PutImage(button1, false);
                        break;
                    }
                case 6:
                    {
                        PutImage(button6, false);
                        break;
                    }
                case 7:
                    {
                        PutImage(button7, false);
                        break;
                    }
                case 8:
                    {
                        PutImage(button8, false);
                        break;
                    }
                case 9:
                    {
                        PutImage(button9, false);
                        break;
                    }
            }
        }

        private void MouseMoveStart(object sender, MouseEventArgs e)
        {
            Storyboard1.Begin();
        }

        private void MoveButtonX(object sender, MouseEventArgs e)
        {
            Storyboard2.Begin();
        }

        private void MoveButtonO(object sender, MouseEventArgs e)
        {
            Storyboard3.Begin();
        }
    }
}
