using _5WorkNormal.Aute;
using _5WorkNormal.DataBaseControl;
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

namespace _5WorkNormal.MainInterfase.TabelePage
{
    /// <summary>
    /// Логика взаимодействия для Shop.xaml
    /// </summary>
    public partial class PageSale : Page
    {
        public PageSale()
        {
            InitializeComponent();
            Update_Grid();
        }
        public List<List<object>> Update_Grid()
        {
            DataFormate.sales = new List<Sale>();
            List<List<object>> DataObjecte = DataBaseCRUD.Conect(DataBaseCRUD.Read, new List<object>(), 9, "sale");
            foreach (List<object> item in DataObjecte)
                DataFormate.sales.Add(new Sale(item));
            ss.ItemsSource = null;
            ss.ItemsSource = DataFormate.sales;
            return DataObjecte;
        }
        private void UpdateCreat(object sender, RoutedEventArgs e)
        {
            UpdateCreate.WindowConfig = "name,fkid_product,quantity,fkid_password_role,fkid_client,fkid_shop,fkid_payment_method,all_cost:string,int,int,int,int,int,int,int";
            UpdateCreate.WindowInput = new List<string>();
            bool CU = ss.SelectedItem != null && Aut.rights;
            object IndexSS = ss.SelectedIndex;
            if (CU)
            {
                int l = ss.SelectedIndex;
                List<List<object>> full = Update_Grid();
                for (int i = 1; i < full[l].Count; i++)
                    UpdateCreate.WindowInput.Add(full[l][i].ToString());
            }
            else
                UpdateCreate.WindowInput = null;
            while (true)
            {
                UpdateCreate.ExitWindow = new List<object>();
                UpdateCreate window = new UpdateCreate();
                bool? DialogResult = window.ShowDialog();
                if (DialogResult == true)
                {
                    if (CU)
                        DataBaseCRUD.Conect(DataBaseCRUD.Update, UpdateCreate.ExitWindow, DataFormate.sales[(int)IndexSS].Id, "sale(name,fkid_product,quantity,fkid_password_role,fkid_client,fkid_shop,fkid_payment_method,all_cost):id_sale");
                    else
                        DataBaseCRUD.Conect(DataBaseCRUD.Create, UpdateCreate.ExitWindow, 0, "sale(name,fkid_product,quantity,fkid_password_role,fkid_client,fkid_shop,fkid_payment_method,all_cost)");
                    Update_Grid();
                }
                if (DialogResult != null)
                    break;
                window.Close();
            }
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ss.SelectedItem != null && Aut.rights)
                DataBaseCRUD.Conect(DataBaseCRUD.Delete, null, DataFormate.sales[ss.SelectedIndex].Id, "sale:id_sale");
            Update_Grid();
        }
        private void CreateMod(object sender, RoutedEventArgs e)
        {
            ss.SelectedItem = null;
        }
    }
}

