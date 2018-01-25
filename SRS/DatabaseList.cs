using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace SRS
{
    public class DatabaseList<T>
    {
        Lista<T> lista;
        String connectionString;
        String tableName;

        public Lista<T> Lista { get => lista; set => lista = value; }

        public DatabaseList(string connectionString, string tableName)
        {
            this.connectionString = connectionString;
            this.tableName = tableName;
            Lista = new Lista<T>();
        }

        public int Select()
        {
            int recordsSelected = 0;
            SqlCommand cmd;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                System.Reflection.PropertyInfo[] propertyInfo = typeof(T).GetProperties();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("SELECT ");
                foreach (var property in propertyInfo)
                {
                    stringBuilder.Append(property.Name);
                    stringBuilder.Append(", ");
                }
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
                stringBuilder.Append(" FROM ");
                stringBuilder.Append(tableName);

                cmd.CommandText = stringBuilder.ToString();

                using (
                SqlDataReader sqlDataReader = cmd.ExecuteReader())
                {
                    Lista.Clear();
                    while (sqlDataReader.Read())
                    {
                        IDataRecord dataRecord = sqlDataReader;

                        T obj = GetInstance<T>(typeof(T).ToString());
                        int i = 0;
                        foreach (var property in propertyInfo)
                        {
                            property.SetValue(obj, dataRecord[i]);
                            i++;
                        }

                        Lista.Add(obj);
                        recordsSelected++;
                    }
                }
            }
            return recordsSelected;
        }

        public int Delete(T obj)
        {
            int i = 0;
            foreach (T item in lista)
            {
                if (item.GetType().GetProperties()[0].GetValue(item).Equals(obj.GetType().GetProperties()[0].GetValue(obj)))
                {
                    SqlCommand cmd;
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;

                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append("DELETE FROM ");
                        stringBuilder.Append(tableName);
                        stringBuilder.Append(" WHERE ");
                        stringBuilder.Append(obj.GetType().GetProperties()[0].Name);
                        stringBuilder.Append(" = '");
                        stringBuilder.Append(obj.GetType().GetProperties()[0].GetValue(obj));
                        stringBuilder.Append(" '");
                        cmd.CommandText = stringBuilder.ToString();
                        cmd.ExecuteScalar();
                    }
                    lista.Remove(item);
                    i++;
                }
            }
            return i;
        }

        public int Insert(T obj)
        {
            int i = 0;
            {
                SqlCommand cmd;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("INSERT INTO ");
                    stringBuilder.Append(tableName);
                    stringBuilder.Append(" ( ");

                    System.Reflection.PropertyInfo[] propertyInfo = typeof(T).GetProperties();
                    bool id = true;
                    foreach (var property in propertyInfo)
                    {
                        if (id)
                        {
                            id = false;
                            continue;
                        }
                        stringBuilder.Append(property.Name);
                        stringBuilder.Append(", ");
                    }
                    stringBuilder.Remove(stringBuilder.Length - 2, 2);
                    stringBuilder.Append(" ) VALUES (");
                    id = true;
                    foreach (var item in obj.GetType().GetProperties())
                    {
                        if (id)
                        {
                            id = false;
                            continue;
                        }
                        stringBuilder.Append("'");
                        stringBuilder.Append(item.GetValue(obj));
                        stringBuilder.Append("'");
                        stringBuilder.Append(", ");
                    }
                    stringBuilder.Remove(stringBuilder.Length - 2, 2);
                    stringBuilder.Append(")");


                    
                    cmd.CommandText = stringBuilder.ToString();
                    cmd.ExecuteScalar();
                }
                Select();
                i++;

            }
            return i;
        }

        public void Update(T obj)
        {
            SqlCommand cmd;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                System.Reflection.PropertyInfo[] propertyInfo = typeof(T).GetProperties();

                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append("UPDATE ");
                stringBuilder.Append(tableName);
                stringBuilder.Append(" SET ");

                int i = 1;
                bool id = true;
                foreach (var property in propertyInfo)
                {
                    if (id)
                    {
                        id = false;
                        continue;
                    }
                    stringBuilder.Append(property.Name);
                    stringBuilder.Append(" = '");
                    stringBuilder.Append(obj.GetType().GetProperties()[i].GetValue(obj));
                    stringBuilder.Append("', ");
                    i++;

                }
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
                stringBuilder.Append(" WHERE ");

                stringBuilder.Append(obj.GetType().GetProperties()[0].Name);
                stringBuilder.Append(" = '");
                stringBuilder.Append(obj.GetType().GetProperties()[0].GetValue(obj));
                stringBuilder.Append(" '");


                cmd.CommandText = stringBuilder.ToString();
                cmd.ExecuteScalar();
                Select();
            }
        }

        private T GetInstance<T>(string type)
        {
            return (T)Activator.CreateInstance(Type.GetType(type));
        }
    }
}