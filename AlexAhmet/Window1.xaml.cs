﻿using Microsoft.Win32;
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
                            logger.Info("Было открыто изображение");
                            TextBox1.Visibility = Visibility.Hidden;
                            Image.Visibility = Visibility.Visible;

                            BitmapImage loadImage = new BitmapImage();
                            loadImage.BeginInit();
                            loadImage.UriSource = new Uri(fileInfo.FullName);
                            loadImage.EndInit();

                            Image.Source = loadImage;

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
                            logger.Info("Был открыт текстовый файл");
                            TextBox1.Visibility = Visibility.Visible;
                            Image.Visibility = Visibility.Hidden;
                            StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.GetEncoding(1251));

                            TextBox1.Text = reader.ReadToEnd();

                            reader.Close();
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
    }
}
    

