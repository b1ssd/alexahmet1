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


namespace AlexAhmet
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public MediaPlayer Player { get; set; }
        public Window2()
        {
            InitializeComponent();

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All files (*.*)|*.*|Wav gavno (*.wav)|*.wav|mp3 po kaify (*.mp3)|*.mp3";

            if (openFileDialog.ShowDialog() == true)
            {
                Uri uri = new Uri(openFileDialog.FileName);
                Player = new MediaPlayer();
                Player.Open(uri);
                Label.Content = openFileDialog.SafeFileName;

            }
        }

        private void Image1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
          Player.Play();
            Image1.Visibility = Visibility.Hidden;
            Image3.Visibility = Visibility.Visible;
        }

        private void Image2_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           Player.Stop();
            Image1.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Hidden;
        }

        private void Image3_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Player.Pause();
            Image1.Visibility = Visibility.Visible;
            Image3.Visibility = Visibility.Hidden;
        }
    }
}
        
         
