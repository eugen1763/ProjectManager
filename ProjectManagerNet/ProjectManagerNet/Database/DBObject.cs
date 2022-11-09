using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectManagerNet.Database
{
    public class DBObject
    {
        public DBObject() { }

        public DBObject(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; set; } = "project_containers";

        [DBInfo(FieldName = "id", Primary = true)]
        public long Id { get; set; }

        [DBInfo(FieldName = "title")]
        public string Title { get; set; }

        [DBInfo(FieldName = "creation")]
        public DateTime Creation { get; set; }

        public static IEnumerable<DBObject> RetrieveAll()
        {
            return Services.DB.RetrieveAll<DBObject>();
        }
    }
}