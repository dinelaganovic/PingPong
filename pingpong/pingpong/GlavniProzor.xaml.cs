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
using System.Windows.Shapes;

namespace pingpong
{
    /// <summary>
    /// Interaction logic for GlavniProzor.xaml
    /// </summary>
    public partial class GlavniProzor : Window
    {
        public GlavniProzor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imeprezime1 = txtIP1.Text;
            string imeprezime2 = txtIP2.Text;
            int brzina;
            try
            {
                brzina = int.Parse(txtBrzina.Text);
            }
            catch
            {
                brzina = 5;
            }
            MainWindow mw = new MainWindow(imeprezime1, imeprezime2, brzina);
            mw.ShowDialog();
        }
    }
}
