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
    /// Логика взаимодействия для PagePayment_method.xaml
    /// </summary>
    public partial class PagePayment_method : Page
    {
        public PagePayment_method()
        {
            InitializeComponent();
            Update_Grid();
        }
        public List<List<object>> Update_Grid()
        {
            DataFormate.paymentMethods = new List<PaymentMethod>();
            List<List<object>> DataObjecte = DataBaseCRUD.Conect(DataBaseCRUD.Read, new List<object>(), 4, "payment_method");
            foreach (List<object> item in DataObjecte)
                DataFormate.paymentMethods.Add(new PaymentMethod(item));
            ss.ItemsSource = null;
            ss.ItemsSource = DataFormate.paymentMethods;
            return DataObjecte;
        }
        private void UpdateCreat(object sender, RoutedEventArgs e)
        {
            UpdateCreate.WindowConfig = "mony,card,crypto:real,real,real";
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
                        DataBaseCRUD.Conect(DataBaseCRUD.Update, UpdateCreate.ExitWindow, DataFormate.paymentMethods[(int)IndexSS].Id, "payment_method(mony,card,crypto):id_payment_method");
                    else
                        DataBaseCRUD.Conect(DataBaseCRUD.Create, UpdateCreate.ExitWindow, 0, "payment_method(mony,card,crypto)");
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
                DataBaseCRUD.Conect(DataBaseCRUD.Delete, null, DataFormate.paymentMethods[ss.SelectedIndex].Id, "payment_method:id_payment_method");
            Update_Grid();
        }
        private void CreateMod(object sender, RoutedEventArgs e)
        {
            ss.SelectedItem = null;
        }
    }
}
