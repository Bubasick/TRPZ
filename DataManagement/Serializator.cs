using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DataManagement
{
    public interface ISerialization
    {
        void Serialization(Object obj, string path);
        Object Deserialization(string path);
    }

    public class XMLSerializator : ISerialization
    {
        DataContractSerializer xmlSerializer;
        public XMLSerializator(Type type)
        {
            xmlSerializer = new DataContractSerializer(type);
        }
        public void Serialization(Object obj, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.WriteObject(stream, obj);
            }
        }

        public Object Deserialization(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                return xmlSerializer.ReadObject(stream);
            }
        }
    }

    class JsonSerializator : ISerialization
    {
        DataContractJsonSerializer jsonSerializer;
        public JsonSerializator(Type type)
        {
            jsonSerializer = new DataContractJsonSerializer(type);
        }
        public void Serialization(Object obj, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(stream, obj);
            }
        }
        public Object Deserialization(string path)
        {
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            {
                return jsonSerializer.ReadObject(stream);
            }
        }

    }

   public class Serializator
    {
        private ISerialization ser;
        public Serializator(ISerialization serial)
        {
            ser = serial;
        }
        public void Serialize(Object obj, string path)
        {
            ser.Serialization(obj, path);
        }

        public Object Deserialize(string path)
        {
            return ser.Deserialization(path);
        }
    }
}
