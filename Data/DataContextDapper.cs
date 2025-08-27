// holds Dapper data

using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HelloWorld.Data
{
    public class DataContextDapper
    {
        private string _connectionString = "Server=LAPTOP-8TJ3KOGR\\MSSQLSERVER01;Database=Tutorial;TrustServerCertificate=true;Trusted_Connection=true;";

        public IEnumerable<T> LoadData<T>(string sqlText)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sqlText);
        }

        public T LoadDataSingle<T>(string sqlText)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sqlText);
        }

        public bool ExecuteSql(string sqlText)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sqlText) > 0;
        }

        public int ExecuteSqlWithRowCount(string sqlText)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sqlText);
        }

    }
}