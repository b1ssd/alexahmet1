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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                
                    StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.GetEncoding(1251));
                    TextBox1.Text = reader.ReadToEnd();
                    reader.Close();
                    return;
                
            }
        }
    }
}
    

