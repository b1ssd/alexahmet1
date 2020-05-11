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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public MediaPlayer Player { get; set; }
        public Window2()
        {
            InitializeComponent();

        }
        private void TimerTick(object sender, EventArgs e)
        {
            DoubleCollection tick = new DoubleCollection();

            double dlina = Convert.ToDouble(Player.NaturalDuration);
            Slider.Maximum = (int)dlina;

            double tekPosition = Convert.ToDouble(Player.Position);
            Slider.Value = (int)tekPosition;
            tick.Add(Slider.Value);
            Slider.Ticks = tick;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "All files (*.*)|*.*|Wav (*.wav)|*.wav|mp3 (*.mp3)|*.mp3";

                if (openFileDialog.ShowDialog() == true)
                {
                    Uri uri = new Uri(openFileDialog.FileName);
                    Player = new MediaPlayer();
                    Player.Open(uri);
                    Label.Content = openFileDialog.SafeFileName;

                }
                logger.Info("Был открыт музыкальный файл");
            }
            catch
            {
                logger.Error("Произошла ошибка при открытии музыкального файла");
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            if (Player != null)
            { 
            timer.Start();
            }
        }
    }
}
        
         
