using System;
using System.Configuration;
using System.IO;

namespace DataManagement
{
    public  class TransferData
    {
        public static object Transfer(Type type)
        {
           string  connectionString = ConfigurationManager.ConnectionStrings["Path"].ConnectionString;
            return new Serializator(new XMLSerializator(type)).Deserialize(connectionString);
    }

      
    }
}