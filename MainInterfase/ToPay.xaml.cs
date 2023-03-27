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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _5WorkNormal.MainInterfase
{
    /// <summary>
    /// Логика взаимодействия для ToPay.xaml
    /// </summary>
    public partial class ToPay : Window
    {
        public static long to_pay;
        public ToPay()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                to_pay = Convert.ToInt64(Pay.Text);
            }
            catch {
                MessageBox.Show("Вводи Данные нормально");
                DialogResult = false;
                return;
            }
            DialogResult = true; 
        }
    }
}
