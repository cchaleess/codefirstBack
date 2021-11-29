using CodeFirst.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            string exception = "";
            string sqlDataSource = _configuration.GetConnectionString("Conexion");
            try
            {
                using (SqlConnection conexion = new SqlConnection(sqlDataSource))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.CommandType = CommandType.Text;
                        await conexion.OpenAsync();
                        rowsAffected = await cmd.ExecuteNonQueryAsync();
                        await conexion.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                exception = ex.ToString();
                return rowsAffected;
            }
            return rowsAffected;
       
}

        public async Task<string> GetJsonFromSql(string query)
        {
            DataTable table = new DataTable();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            string sqlDataSource = _configuration.GetConnectionString("Conexion");
            try
            {
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
            }
            catch (Exception ex)
            {
                string excepcion = ex.ToString();
                return excepcion;
            }
            return serializer.Serialize(rows);
        }
    }
}
