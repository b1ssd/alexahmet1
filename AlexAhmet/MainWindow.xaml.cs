using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NLog;
using NLog.Fluent;

namespace AlexAhmet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logger.Info("Была нажата кнопка 'Файл'");

                Window1 window1 = new Window1();
                window1.Show();
                window1.Owner = this;
            }
            catch
            {
                logger.Error("Произошла ошибка при попытке нажатия кнопки 'Файл'");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                logger.Info("Была нажата кнопка 'Аудиоплеер'");

                Window2 window2 = new Window2();
                window2.Show();
                window2.Owner = this;
            }
            catch
            {
                logger.Error("Произошла ошибка при попытке нажатия кнопки 'Аудиоплеер'");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                logger.Info("Была нажата кнопка 'О программе'");
                Window3 window3 = new Window3();
                window3.Show();
                window3.Owner = this;
            }
            catch
            {
                logger.Error("Произошла ошибка при попытке нажатия кнопки 'О программе'");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                logger.Info("Была нажата кнопка 'Настройки'");
                Window4 window4 = new Window4();
                window4.Show();
                window4.Owner = this;
            }
            catch
            {
                logger.Error("Произошла ошибка при попытке нажатия кнопки 'Настройки'");
            }
        }
    }
}
