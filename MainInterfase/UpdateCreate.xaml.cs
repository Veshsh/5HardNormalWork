using _5WorkNormal.Aute;
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
    /// Логика взаимодействия для UpdateCreate.xaml
    /// </summary>
    public partial class UpdateCreate : Window
    {
        public static string WindowConfig;
        public static List<string> WindowInput= null;
        public static List<object> ExitWindow = new List<object>();
        public static List<TextBox> TextBoxs = new List<TextBox>();
        public UpdateCreate()
        {
            InitializeComponent();
            {
                PageContent.ColumnDefinitions.Add(new ColumnDefinition());
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.Width = new GridLength(3, GridUnitType.Star);
                PageContent.ColumnDefinitions.Add(columnDefinition);
                string[] Text = WindowConfig.Split(':')[0].Split(',');
                for (int i = 0; i < Text.Length; i++)
                {
                    TextBoxs.Add(new TextBox());
                    PageContent.RowDefinitions.Add(new RowDefinition());
                    TextBoxs[i] = new TextBox();
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = Text[i];
                    Grid.SetRow(textBlock, i);
                    textBlock.VerticalAlignment = VerticalAlignment.Center;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetColumn(textBlock, 0);
                    PageContent.Children.Add(textBlock);
                    TextBoxs[i].Text = (WindowInput != null) ? WindowInput[i]:"";
                    Grid.SetRow(TextBoxs[i], i);
                    Grid.SetColumn(TextBoxs[i], 1);
                    PageContent.Children.Add(TextBoxs[i]);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] Text = WindowConfig.Split(':')[1].Split(',');
            bool? DialogResulte = true;
            try
            {
                for (int i = 0; i < Text.Length; i++)
                {

                    switch (Text[i])
                    {
                        case ("int"):
                            int con1 = Convert.ToInt32(TextBoxs[i].Text);
                            ExitWindow.Add(con1);
                            break;
                        case ("string"):
                            string con2 = Convert.ToString(TextBoxs[i].Text);
                            if (con2.Length >= 14)
                                DialogResulte = Catch();
                            ExitWindow.Add(con2);
                            break;
                        case ("bool"):
                            bool con3 = Convert.ToBoolean(TextBoxs[i].Text);
                            ExitWindow.Add(con3);
                            break;
                        case ("real"):
                            decimal con4 = Convert.ToDecimal(TextBoxs[i].Text);
                            ExitWindow.Add(con4);
                            break;
                        case ("hashsalt"):
                            string con5 = Convert.ToString(TextBoxs[i].Text);
                            if (con5.Length >= 14)
                                DialogResulte = Catch();
                            string salt = hash.GenerateSalt();
                            ExitWindow.Add(hash.CreateHash(con5, salt));
                            ExitWindow.Add(salt);
                            break;
                        case ("long"):
                            long con6 = Convert.ToInt64(TextBoxs[i].Text);
                            ExitWindow.Add(con6);
                            break;
                    }
                }
            }
            catch 
            {
                DialogResulte = Catch(); 
            }
            DialogResult = DialogResulte;
        }
        private bool? Catch()
        {
            MessageBox.Show("Вводи данные нормально");
            return null;
        }
    }
}
