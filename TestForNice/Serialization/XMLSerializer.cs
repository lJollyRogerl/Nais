using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Instances;
using System.Windows;

namespace TestForNice.SerializationApproach
{
    public class XMLSerializer : ICustomSerializer
    {
        //WriteToFile is serializing a generic object to an xml file by the given path 
        public void WriteToFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            XmlSerializer xser = new XmlSerializer(typeof(List<Employee>));
            using (var fStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                xser.Serialize(fStream, objectToWrite);
            }
        }
        //ReadFromFile is deserializing a generic object from an xml file by the given path 
        public T ReadFromFile<T>(string filePath)
        {

            XmlSerializer xser = new XmlSerializer(typeof(T));
            using (var fStream = new FileStream(filePath, FileMode.Open))
            {
                return (T)xser.Deserialize(fStream);
            }
            
        }
        //An extension of file to work with
        public string ExtensionOfTheFile
        {
            get
            {
                return ".xml";
            }
        }

    }
}
