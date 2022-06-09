using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace App
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider()
        {
            //Chuyển định dạng về dd/mm/yy để sử dụng hàm CONVERT(datetime, string_datetime, numFormatType) của SQLSERVER
            CultureInfo cul = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = cul;
            Thread.CurrentThread.CurrentUICulture = cul;
        }

        public string stMSTS { get; set; } = ConfigurationManager.AppSettings["MSTS"].ToString();

        private string stConnection = ConfigurationManager.AppSettings["stCnn"].ToString();

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(stConnection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(GetSqlCommandWithPara(connection, query, parameter));
                adapter.Fill(data);
                adapter.Dispose();
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(stConnection))
            {
                connection.Open();                
                data = GetSqlCommandWithPara(connection, query, parameter).ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(stConnection))
            {
                connection.Open();                
                data = GetSqlCommandWithPara(connection, query, parameter).ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        private SqlCommand GetSqlCommandWithPara(SqlConnection connection, string query, object[] parameter = null)
        {
            SqlCommand command = new SqlCommand(query, connection);
            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }            
            return command;
        }

        public DataTable ListToDataTable<T>(IList data)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public List<T> DataTableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public void EditAppSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public Dictionary<string, string> GetAppSetting()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Dictionary<string, string> dicSetting = new Dictionary<string, string>();
            foreach (KeyValueConfigurationElement kv in config.AppSettings.Settings)
            {
                dicSetting.Add(kv.Key, kv.Value);
            }
            return dicSetting;
        }
    }
}
