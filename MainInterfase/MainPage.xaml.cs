using _5WorkNormal.Aute;
using _5WorkNormal.DataBaseControl;
using _5WorkNormal.MainInterfase.TabelePage;
using _5WorkNormal.SerrializeChek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

namespace _5WorkNormal.MainInterfase
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            PageChoice.SelectedIndex = 0;
            PageChoice.ItemsSource = (Aut.rights) ? new List<string>() { "sale", "client", "contact", "product", "type", "provider", "shop", "payment_method", "user_", "password_role" } : new List<string>() { "sale", "client", "contact" };
        }
        private void Select_Page(object sender, SelectionChangedEventArgs e)
        {
            List<Page> a = new List<Page>() {new PageSale(), new PageClient(), new PageContact(), new PageProduct(), new PageType(), new PageProvider(), new PageShop(), new PagePayment_method(),new PageUser_(), new PagePassword_role()};
            SelectPage.Content = a[PageChoice.SelectedIndex];
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Aut());
        }
        private void Button_Check(object sender, RoutedEventArgs e)
        {
            ToPay window = new ToPay();
            if (window.ShowDialog() == true)
                Serrializer.Check(DataBaseCRUD.Conect(DataBaseCRUD.Read, new List<object>(), 9, "sale"), ToPay.to_pay);
            
        }
        private void Button_Import(object sender, RoutedEventArgs e)
        {
            WindowChous windowChous = new WindowChous();
            windowChous.ShowDialog();
            windowChous.Close();
            SelectPage.Content = new PageSale();
            SelectPage.Content = new PageContact();
        }
    }
}
