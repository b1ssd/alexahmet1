using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using NLog;


namespace AlexAhmet
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public Window1()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                logger.Info("Была нажата кнопка открытия файла");

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "All files (*.*)|*.*|PNG Photos (*.png)|*.png|Text files (*.txt)|*.txt";

                if (openFileDialog.ShowDialog() == true)
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                    if (fileInfo.Extension.ToLower() == ".png")
                    {
                        try
                        {
                            
                            TextBox1.Visibility = Visibility.Hidden;
                            Image.Visibility = Visibility.Visible;

                            BitmapImage loadImage = new BitmapImage();
                            loadImage.BeginInit();
                            loadImage.UriSource = new Uri(fileInfo.FullName);
                            loadImage.EndInit();

                            Image.Source = loadImage;
                            logger.Info("Было открыто изображение");
                            return;
                            
                        }
                        catch
                        {
                            logger.Error("Произошла ошибка при попытке открытия изображения");
                        }
                    }

                    if (fileInfo.Extension.ToLower() == ".txt")
                    {
                        try
                        {
                            TextBox1.IsReadOnly = true;                           
                            TextBox1.Visibility = Visibility.Visible;
                            Image.Visibility = Visibility.Hidden;
                            StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.GetEncoding(1251));

                            TextBox1.Text = reader.ReadToEnd();

                            reader.Close();
                            logger.Info("Был открыт текстовый файл");
                            return;
                            
                        }
                        catch
                        {
                            logger.Error("Произошла ошибка при попытке открытия текстового файла");
                        }
                    }
                }
            }

            catch
            {
                logger.Error("Произошла ошибка при попытке открытия файла");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                logger.Info("Была нажата кнопка возвращения в меню");

            }
            catch
            {
                logger.Error("Проищошла ошибка при попытке возвращения в меню");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "";
            TextBox1.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Hidden;
        }
    }
}
    

