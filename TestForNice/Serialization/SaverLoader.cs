using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestForNice
{
    public class SaverLoader
    {
        public SaverLoader(ICustomSerializer serializer)
        {
            internalSerializer = serializer;
        }
        //Object, which will be serializing our data is stored here
        private ICustomSerializer internalSerializer { get; set; }
        //Save function asks a user for a path where to store the file
        //and serializing it with the help of ICustomSerializer object
        public void Save<T>(T objToSave) where T : class
        {
            try
            {
                var saveFile = new System.Windows.Forms.SaveFileDialog();
                saveFile.Filter = String.Format("Таблица (*{0}) | *{0}", internalSerializer.ExtensionOfTheFile);
                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String pathToFile = saveFile.FileName;
                    internalSerializer.WriteToFile<T>(pathToFile, objToSave);
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Ошибка при сохранении данных!", ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что то пошло не так. Очень жаль!", ex.Message);
                throw;
            }
        }
        //Save function asks a user for a path from where to get the file with data
        //and deserializing it with the help of ICustomSerializer object
        public T Load<T>() where T: class
        {
            try
            {
                var openFile = new System.Windows.Forms.OpenFileDialog();
                openFile.Filter = String.Format("Таблица (*{0}) | *{0}", internalSerializer.ExtensionOfTheFile);
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    String pathToFile = openFile.FileName;
                    return internalSerializer.ReadFromFile<T>(pathToFile);
                }
                return null;
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Ошибка десериализации. Ваш файл поврежден!", ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                if (ex.InnerException.GetType() == typeof(FormatException))
                {
                    MessageBox.Show("Ошибка десериализации. Ваш файл поврежден!", ex.Message);
                    return null;
                }
                else
                    MessageBox.Show("Что то пошло не так. Очень жаль! :(", ex.Message);
                throw;
            }
        }

    }
}
