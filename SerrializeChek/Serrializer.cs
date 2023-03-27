using _5WorkNormal.DataBaseControl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace _5WorkNormal.SerrializeChek
{
    class Serrializer
    {
        public static void Check(List<List<object>> Check,long topay)
        {
            string text = "\t   <5WorkNormal>\n\t  Кассовый чек №<ID в БД>\n";
            long quantity = 0;
            foreach (var item in Check)
            {
                quantity += (int)item[2];
                text += item[1] + "\t" + item[8] + '\n';
            }
            text += "Итого к оплате: "+ quantity+ "\nВнесено: "+ topay + "\nСдача: "+ (topay-quantity);
            File.WriteAllText("C:\\Users\\vanya\\source\\repos\\5WorkNormal\\5WorkNormal\\SerrializeChek\\chek.txt",text);
        }
        public static List<List<object>> ListsSales()
        {
            List<List<object>> ser = new List<List<object>>();
            List<Sale> sale = new List<Sale>();
            sale = JsonConvert.DeserializeObject<List<Sale>>(File.ReadAllText("C:\\Users\\vanya\\source\\repos\\5WorkNormal\\5WorkNormal\\SerrializeChek\\json1.json"));
            foreach (var item in sale)
            {
                List<object> list = new List<object>();
                list.Add(item.Name);
                list.Add(item.Fkid_product);
                list.Add(item.Quantity);
                list.Add(item.Fkid_password_role);
                list.Add(item.Fkid_client);
                list.Add(item.Fkid_shop);
                list.Add(item.Fkid_payment_method);
                list.Add(item.All_cost);
                ser.Add(list);
            }
            return ser;
        }
        public static List<List<object>> ListsContact()
        {
            List<List<object>> ser = new List<List<object>>();
            List<Contact> sale = new List<Contact>();
            sale = JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText("C:\\Users\\vanya\\source\\repos\\5WorkNormal\\5WorkNormal\\SerrializeChek\\json2.json"));
            foreach (var item in sale)
            {
                List<object> list = new List<object>();
                list.Add(item.Adres);
                list.Add(item.PhoneNumber);
                list.Add(item.Email);
                ser.Add(list);
            }
            return ser;
        }
    }
}
