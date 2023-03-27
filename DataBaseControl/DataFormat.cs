using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5WorkNormal.DataBaseControl
{
    class Contact
    {
        public int Id { get; set; }
        public int Adres { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public Contact(List<object> objecte=null)
        {
            if (objecte != null)
            {
                Id = (int)objecte[0];
                Adres = (int)objecte[1];
                PhoneNumber = (long)objecte[2];
                Email = (string)objecte[3];
            }
        }
    }
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Regular { get; set; }
        public bool Card_store { get; set; }
        public int Fkid_contact { get; set; }
        public Client(List<object> objecte)
        {
            Id = (int)objecte[0];
            Name = (string)objecte[1];
            Regular = (bool)objecte[2];
            Card_store = (bool)objecte[3];
            Fkid_contact = (int)objecte[4];
        }
    }
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fkid_type { get; set; }
        public int Fkid_provider { get; set; }
        public int Cost { get; set; }
        public Product(List<object> objecte)
        {
            Id = (int)objecte[0];
            Name = (string)objecte[1];
            Fkid_type = (int)objecte[2];
            Fkid_provider = (int)objecte[3];
            Cost = (int)objecte[4];
        }
    }
    class Type_
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public Type_(List<object> objecte)
        {
            Id = (int)objecte[0];
            Name = (string)objecte[1];
            Department = (string)objecte[2];
        }
    }
    class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fkid_contact { get; set; }
        public Provider(List<object> objecte)
        {
            Id = (int)objecte[0];
            Name = (string)objecte[1];
            Fkid_contact = (int)objecte[2];
        }
    }
    class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fkid_contact { get; set; }
        public Shop(List<object> objecte)
        {
            Id = (int)objecte[0];
            Name = (string)objecte[1];
            Fkid_contact = (int)objecte[2];
        }
    }
    class PaymentMethod
    {
        public int Id { get; set; }
        public decimal Mony { get; set; }
        public decimal Card { get; set; }
        public decimal Crypto { get; set; }
        public PaymentMethod(List<object> objecte)
        {
            Id = (int)objecte[0];
            Mony = Convert.ToDecimal(objecte[1]);
            Card = Convert.ToDecimal(objecte[2]);
            Crypto = Convert.ToDecimal(objecte[3]);
        }
    }
    class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public User(List<object> objecte)
        {
            Id = (int)objecte[0];
            Login = (string)objecte[1];
        }
    }
    class PasswordRole
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public bool Role { get; set; }
        public int Fkid_user { get; set; }
        public PasswordRole(List<object> objecte)
        {
            Id = (int)objecte[0];
            Hash = (string)objecte[1];
            Salt = (string)objecte[2];
            Role = (bool)objecte[3];
            Fkid_user = (int)objecte[4];
        }
    }
    class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Fkid_product { get; set; }
        public int Quantity { get; set; }
        public int Fkid_password_role { get; set; }
        public int Fkid_client { get; set; }
        public int Fkid_shop { get; set; }
        public int Fkid_payment_method { get; set; }
        public int All_cost { get; set; }
        public Sale(List<object> objecte=null)
        {
            if (objecte != null)
            {
                Id = (int)objecte[0];
                Name = (string)objecte[1];
                Fkid_product = (int)objecte[2];
                Quantity = (int)objecte[3];
                Fkid_password_role = (int)objecte[4];
                Fkid_client = (int)objecte[5];
                Fkid_shop = (int)objecte[6];
                Fkid_payment_method = (int)objecte[7];
                All_cost = (int)objecte[8];
            }
        }
    }
    class DataFormate
    {
        public static List<Contact> contacts = new List<Contact>();
        public static List<Client> clients = new List<Client>();
        public static List<Product> products = new List<Product>();
        public static List<Type_> types = new List<Type_>();
        public static List<Provider> providers = new List<Provider>();
        public static List<Shop> shops = new List<Shop>();
        public static List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
        public static List<User> users = new List<User>();
        public static List<PasswordRole> passwordRoles = new List<PasswordRole>();
        public static List<Sale> sales = new List<Sale>();
    }
}