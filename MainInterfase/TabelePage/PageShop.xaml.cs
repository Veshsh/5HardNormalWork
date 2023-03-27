using _5WorkNormal.Aute;
using _5WorkNormal.DataBaseControl;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace _5WorkNormal.MainInterfase.TabelePage
{
    /// <summary>
    /// Логика взаимодействия для PageShop.xaml
    /// </summary>
    public partial class PageShop : Page
    {
        public PageShop()
        {
            InitializeComponent();
            Update_Grid();
        }
        public List<List<object>> Update_Grid()
        {
            DataFormate.shops = new List<Shop>();
            List<List<object>> DataObjecte = DataBaseCRUD.Conect(DataBaseCRUD.Read, new List<object>(), 3, "shop");
            foreach (List<object> item in DataObjecte)
                DataFormate.shops.Add(new Shop(item));
            ss.ItemsSource = null;
            ss.ItemsSource = DataFormate.shops;
            return DataObjecte;
        }
        private void UpdateCreat(object sender, RoutedEventArgs e)
        {
            UpdateCreate.WindowConfig = "name,fkid_contact:string,int";
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
                        DataBaseCRUD.Conect(DataBaseCRUD.Update, UpdateCreate.ExitWindow, DataFormate.shops[(int)IndexSS].Id, "shop(name,fkid_contact):id_shop");
                    else
                        DataBaseCRUD.Conect(DataBaseCRUD.Create, UpdateCreate.ExitWindow, 0, "shop(name,fkid_contact)");
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
                DataBaseCRUD.Conect(DataBaseCRUD.Delete, null, DataFormate.shops[ss.SelectedIndex].Id, "shop:id_shop");
            Update_Grid();
        }
        private void CreateMod(object sender, RoutedEventArgs e)
        {
            ss.SelectedItem = null;
        }
    }
}
