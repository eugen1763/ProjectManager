using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ProjectManagerNet.Helpers;

namespace ProjectManagerNet.Database
{
    public sealed class DBManager
    {
        #region Singleton

        protected DBManager() { }

        private static DBManager _instance;
        public static DBManager Instance => _instance ?? (_instance = new DBManager());

        #endregion

        #region Constants

        private const string Host = "89.58.59.219";
        private const string Database = "bkh_project_management";

        #endregion

        public NpgsqlConnection Connection { get; set; }

        public async Task Init()
        {
            var connString = $"Host={Host};Username={Services.Login.Username};Password={Services.Login.Password};Database={Database}";
            
            Connection = new NpgsqlConnection(connString);
            await Connection.OpenAsync();
        }

        public void Kill()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        public void ExecuteSql(string sql)
        {
            var command = new NpgsqlCommand(sql);
            var reader = command.ExecuteReader();

            var result = "";
            while (reader.Read())
                result += reader.GetString(0);

            reader.Close();
        }

        public Dictionary<PropertyInfo, DBInfo> GetProperties<T>() where T : DBObject
        {
            var allProperties = typeof(T).GetProperties();
            var propertyInfos = allProperties.Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(DBInfo)));
            return propertyInfos.ToDictionary(x => x, x => x.GetCustomAttribute(typeof(DBInfo)) as DBInfo);
        }

        public IEnumerable<T> RetrieveAll<T>() where T : DBObject
        {
            var table = typeof(T).GetProperty("TableName", BindingFlags.Static)?.GetValue(null);
            var properties = GetProperties<T>();
            var builder = new StringBuilder();

            builder.AppendLine("SELECT");
            builder.AppendLine(string.Join(", ", properties.Select(x => x.Value.FieldName)));
            builder.AppendLine("FROM");
            builder.AppendLine(table.ToString());
            builder.AppendLine(";");

            return null;
        }
    }
}