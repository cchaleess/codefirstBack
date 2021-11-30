using CodeFirst.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodeFirst.Services
{
    public class ConnectionSqlService : IConnectionSqlService
    {
        private readonly IConfiguration _configuration;
        private string ConnectionString;
        public ConnectionSqlService(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conexion");
        }

        public async Task<int> CrudDataToSql(string query)
        {
            DataTable table = new DataTable();
            int rowsAffected = 0;
            string sqlDataSource = _configuration.GetConnectionString("Conexion");
            using (SqlConnection conexion = new SqlConnection(sqlDataSource))
            {
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.Text;
                    await conexion.OpenAsync();
                    rowsAffected = Convert.ToInt32(cmd.ExecuteScalar());
                    await conexion.CloseAsync();
                }
            }
         
            return rowsAffected;
       
}

        public DataTable GetDataTableFromSql(string query)
        {
            DataTable table = new DataTable();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            string sqlDataSource = _configuration.GetConnectionString("Conexion");
            try
            {
                using (SqlConnection connexion = new SqlConnection(sqlDataSource))
                {
                    connexion.Open();

                    SqlDataReader myReader;
                    SqlCommand myCommand = new SqlCommand();
                    myCommand.CommandText = query;
                    myCommand.Connection = connexion;
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connexion.Close();

                }
            }
            catch (Exception ex)
            {
                string exception = ex.ToString();
                return null;
            }
            return table;
        }

        public async Task<string> GetJsonFromSql(string query)
        {
            DataTable table = new DataTable();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            string sqlDataSource = _configuration.GetConnectionString("Conexion");
         
                using (SqlConnection conexion = new SqlConnection(sqlDataSource))
                {
                    await conexion.OpenAsync();

                    SqlDataReader sqlDataReader;
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = query;
                    sqlCommand.Connection = conexion;
                    sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    table.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in table.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in table.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    await conexion.CloseAsync();

                }
         
            return serializer.Serialize(rows);
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}
