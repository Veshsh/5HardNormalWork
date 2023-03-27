using _5WorkNormal.DataBaseControl;
using _5WorkNormal.MainInterfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace _5WorkNormal.Aute
{
    /// <summary>
    /// Логика взаимодействия для Aut.xaml
    /// </summary>
    public partial class Aut : Page
    {
        public static bool rights;
        public Aut()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int? id = null;
            List<List<object>> DataObjecte = DataBaseCRUD.Conect(DataBaseCRUD.Read, null, 2, "user_");
            foreach (List<object> item in DataObjecte)
                if (((string)item[1]).Replace(" ", String.Empty) == Login.Text.Replace(" ", String.Empty))
                    id = (int)item[0];
            DataObjecte = null;
            if (id == null)
                MessageBox.Show("Неверный логин");
            else
            {
                bool check = true;
                DataObjecte = DataBaseCRUD.Conect(DataBaseCRUD.Read, new List<object>(), 5, "password_role");
                foreach (List<object> item in DataObjecte)
                    if ((int)item[4] == id)
                    {
                        string Hash = hash.CreateHash(Password.Password, (string)item[2]);
                        if (Hash == ((string)item[1]))
                        {
                            check = false;
                            rights = (bool)item[3];
                            NavigationService.Navigate(new MainPage());
                        }
                    }
                if(check)
                    MessageBox.Show("Неверный пароль");
            }
        }
    }
}
