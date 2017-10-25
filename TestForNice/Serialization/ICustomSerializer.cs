using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForNice
{
    //with help of the interface you can set up your own serializer and give the instance
    //of it to SaverLoader which will ask a path from a user and save/restore the data
    public interface ICustomSerializer
    {
        void WriteToFile<T>(string filePath, T objectToWrite, bool append = false);
        T ReadFromFile<T>(string filePath);
        String ExtensionOfTheFile { get; }
    }
}
