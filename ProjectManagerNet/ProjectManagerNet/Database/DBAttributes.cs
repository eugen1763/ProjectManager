using System;

namespace ProjectManagerNet.Database
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DBInfo : Attribute
    {
        public bool Primary { set; get; }
        public string FieldName { get; set; }
    }
}