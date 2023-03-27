using _5WorkNormal.DataBaseControl;
using _5WorkNormal.MainInterfase.TabelePage;
using _5WorkNormal.SerrializeChek;
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

namespace _5WorkNormal.MainInterfase
{
    /// <summary>
    /// Логика взаимодействия для WindowChous.xaml
    /// </summary>
    public partial class WindowChous : Window
    {
        public WindowChous()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (List<object> item in Serrializer.ListsSales())
                DataBaseCRUD.Conect(DataBaseCRUD.Create, item, 0, "sale(name,fkid_product,quantity,fkid_password_role,fkid_client,fkid_shop,fkid_payment_method,all_cost)");
            DialogResult =true;   
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (List<object> item in Serrializer.ListsContact())
                DataBaseCRUD.Conect(DataBaseCRUD.Create, item, 0, "contact(address,phone_number,email)");
            DialogResult = false;
        }
    }
}
