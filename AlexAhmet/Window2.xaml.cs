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
        public System.Media.SoundPlayer Sound { get; set; }

        public Window2()
        {
            InitializeComponent();

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All files (*.*)|*.*|музло бля (*.wav)|*.wav";

            if (openFileDialog.ShowDialog() == true)
            {
                Sound = new System.Media.SoundPlayer(openFileDialog.FileName);
                Label.Content = openFileDialog.SafeFileName;

            }
        }

        private void Image1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Sound.Play();
        }

        private void Image2_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Sound.Stop();
        }
    }
}
        
         
