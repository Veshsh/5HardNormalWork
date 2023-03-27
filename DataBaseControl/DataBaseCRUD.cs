using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _5WorkNormal.DataBaseControl
{
    class DataBaseCRUD
    {
        public delegate List<List<object>> BDComandCRUD(NpgsqlConnection conn, List<object> DataObject, int id, string comand);
        public static BDComandCRUD Create = (NpgsqlConnection conn, List<object> DataObject/*Обязательный*/, int id/*Не обязательный*/, string comand/*Имя БД и Считываемые параметры*/) =>
        {
            try
            {
                List<string> BDelement = comand.Replace(" ", String.Empty).Split('(', ')')[1].Split(',').ToList();
                string values = "";
                foreach (string par in BDelement)
                    values += ('@' + par + ',');
                values = values.TrimEnd(',').Replace(" ", String.Empty);
                using (NpgsqlCommand command = new NpgsqlCommand("insert into " + comand + " values (" + values + ")", conn))
                {
                    for (int i = 0; i < BDelement.Count; i++)
                        command.Parameters.AddWithValue(BDelement[i], DataObject[i]);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Не Существующий FK");
            }
            return null;
        };
        public static BDComandCRUD Read = (NpgsqlConnection conn, List<object> DataObject/*Не обязательный*/, int ColumnCount/*Обязательный это длинна*/, string comand/*Имя БД*/) =>
        {
            List<List<object>> DataObjecte = new List<List<object>>();
            using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM " + comand, conn))
            {
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    List<object> line = new List<object>();
                    for (int i = 0; i < ColumnCount; i++)
                        line.Add(reader.GetValue(i));
                    DataObjecte.Add(line);
                }
            }
            return DataObjecte;
        };
        public static BDComandCRUD Update = (NpgsqlConnection conn, List<object> DataObject/*Обязательный*/, int id/*Обязательный*/, string comand/*Имя БД и Считываемые параметры*/) =>
        {
        try
        {
            List<string> BDelement = comand.Replace(" ", String.Empty).Split('(', ')')[1].Split(',').ToList();
                string values = "";
                foreach (string par in BDelement)
                    values += (par + " = @" + par + ',');
                values = values.TrimEnd(',').Replace(" ", String.Empty);
                using (NpgsqlCommand command = new NpgsqlCommand("UPDATE " + comand.Split('(')[0] + " SET " + values + " WHERE " + comand.Split(':')[1] + " = @id", conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    for (int i = 0; i < BDelement.Count; i++)
                        command.Parameters.AddWithValue(BDelement[i], DataObject[i]);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Не Существующий FK");
            }
            return null;
        };
        public static BDComandCRUD Delete = (NpgsqlConnection conn, List<object> DataObject/*Не Обязательный*/, int id/*Обязательный*/, string comand/*Имя БД и Считываемые параметры*/) =>
        {
            List<string> BDelement = comand.Split(':').ToList();
            using (NpgsqlCommand command = new NpgsqlCommand("DELETE FROM " + BDelement[0] + " WHERE " + BDelement[1] + " = @id", conn))
            {
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
            return null;
        };
        public static List<List<object>> Conect(BDComandCRUD comand, List<object> DataObject, int id, string comande)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=123;Database=work1; Pooling = true;"))
            {
                conn.Open();
                List<List<object>> a = comand(conn, DataObject, id, comande);
                conn.Close();
                return a;
            }
        }
    }
}
