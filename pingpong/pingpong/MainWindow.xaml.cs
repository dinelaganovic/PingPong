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
using System.Windows.Threading;

namespace pingpong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int LoptaLeft { get; set; }
        public int LoptaTop { get; set; }
        public int ReketLeft { get; set; }
        public int ReketTop { get; set; }
        public int Reket2Left { get; set; }
        public int Reket2Top { get; set; }
        public int BrzinaTop { get; set; }
        public int BrzinaLeft { get; set; }
        public string ImePrezime1 { get; set; }

        private int brzina;

        public string ImePrezime2 { get; set; }
        public int Rezultat1 { get; set; }
        public int Rezultat2 { get; set; }

        DispatcherTimer timer = new DispatcherTimer();
        Random r = new Random();
        public MainWindow(string imeprezime1, string imeprezime2, int brzina)
        {
            InitializeComponent();
            ImePrezime2 = imeprezime2;
            ImePrezime1 = imeprezime1;
            this.brzina = brzina;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
                if (ReketLeft < 462)
                    ReketLeft += 5;
            if (e.Key == Key.Left)
                if (ReketLeft > 0)
                    ReketLeft -= 5;
            Canvas.SetLeft(reket, ReketLeft);
            if (e.Key == Key.E)
                if (Reket2Left < 462)
                    Reket2Left += 5;
            if (e.Key == Key.Q)
                if (Reket2Left > 0)
                    Reket2Left -= 5;
            Canvas.SetLeft(reket2, Reket2Left);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            Pocetak();
            timer.Start();
        }

        private void Pocetak()
        {
            ReketTop = 329;
            ReketLeft = 0;
            Reket2Left = 0;
            Reket2Top = 0;
            StvaranjeLopte();
            Rezultat1 = 0;
            Rezultat2 = 0;
            this.Title = $"Igrac {ImePrezime1} : {Rezultat1} protiv {ImePrezime2} {Rezultat2}";
        }

        private void StvaranjeLopte()
        {
            BrzinaLeft = brzina;
            BrzinaTop = brzina;
            LoptaLeft = r.Next(0, 500);
            Canvas.SetLeft(lopta, LoptaLeft);
            LoptaTop = 150;
            Canvas.SetTop(lopta, LoptaTop);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (LoptaLeft >= ReketLeft && LoptaLeft <= (ReketLeft + 100) && LoptaTop > 285)
            {
                BrzinaTop += 5;
                BrzinaTop = -BrzinaTop;
            }
            if (LoptaLeft >= Reket2Left && LoptaLeft <= (Reket2Left + 100) && LoptaTop < 30)
            {
                BrzinaTop -= 5;
                BrzinaTop = -BrzinaTop;
            }
            if (LoptaLeft > 530 || LoptaLeft < 0)
            {
                BrzinaLeft = -BrzinaLeft;
            }

            LoptaLeft += BrzinaLeft;
            LoptaTop += BrzinaTop;

            Canvas.SetLeft(lopta, LoptaLeft);
            Canvas.SetTop(lopta, LoptaTop);

            if (LoptaTop > 330)
            {
                Rezultat2++;
                StvaranjeLopte();
            }
            if (LoptaTop < 0)
            {
                Rezultat1++;
                StvaranjeLopte();
            }
            ProveraPobednika();
            this.Title = $"Igrac {ImePrezime1} : {Rezultat1} protiv {ImePrezime2} {Rezultat2}";
        }

        private void ProveraPobednika()
        {
            if (Rezultat2 == 10)
            {
                MessageBox.Show("Pobedio je igrac " + ImePrezime2);
                timer.Stop();
            }
            if (Rezultat1 == 10)
            {
                MessageBox.Show("Pobedio je igrac " + ImePrezime1);
                timer.Stop();
            }
        }
    }
}
