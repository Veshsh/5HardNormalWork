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
    /// Логика взаимодействия для PagePassword_role.xaml
    /// </summary>
    public partial class PagePassword_role : Page
    {
        public PagePassword_role()
        {
            InitializeComponent();
            Update_Grid();
        }
        public void Update_Grid()
        {
            DataFormate.passwordRoles = new List<PasswordRole>();
            List<List<object>> DataObjecte = DataBaseCRUD.Conect(DataBaseCRUD.Read, new List<object>(), 5, "password_role");
            foreach (List<object> item in DataObjecte)
                DataFormate.passwordRoles.Add(new PasswordRole(item));
            ss.ItemsSource = null;
            ss.ItemsSource = DataFormate.passwordRoles;
        }
        private void UpdateCreat(object sender, RoutedEventArgs e)
        {
            UpdateCreate.WindowConfig = "password,role,fkid_user:hashsalt,bool,int";
            UpdateCreate.WindowInput = null;
            bool CU = ss.SelectedItem != null && Aut.rights;
            object IndexSS = ss.SelectedIndex;
            while (true)
            {
                UpdateCreate.ExitWindow = new List<object>();
                UpdateCreate window = new UpdateCreate();
                bool? DialogResult = window.ShowDialog();
                if (DialogResult == true)
                {
                    if (CU)
                        DataBaseCRUD.Conect(DataBaseCRUD.Update, UpdateCreate.ExitWindow, DataFormate.passwordRoles[(int)IndexSS].Id, "password_role(hash,salt,role,fkid_user):id_password_role");
                    else
                        DataBaseCRUD.Conect(DataBaseCRUD.Create, UpdateCreate.ExitWindow, 0, "password_role(hash,salt,role,fkid_user)");
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
                DataBaseCRUD.Conect(DataBaseCRUD.Delete, null, DataFormate.passwordRoles[ss.SelectedIndex].Id, "password_role:id_password_role");
            Update_Grid();
        }
        private void CreateMod(object sender, RoutedEventArgs e)
        {
            ss.SelectedItem = null;
        }
    }
}
