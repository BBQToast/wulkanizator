using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApp1.Klasy
{
    class Pliki
    {
        public void Serialize<T>(T emps, String filename)
        {
            //Create the stream to add object into it.
            System.IO.Stream ms = File.OpenWrite(filename);
            //Format the object as Binary
            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object
            formatter.Serialize(ms, emps);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }
        //Deserializing the List
        public T Deserialize<T>(String filename)
        {
            //Format the object as Binary
            BinaryFormatter formatter = new BinaryFormatter();
            //Reading the file from the server
            FileStream fs = File.Open(filename, FileMode.Open);
            //It deserializes the file as object.
            object obj = formatter.Deserialize(fs);
            //Generic way of setting typecasting object.
            T emps = (T)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();
            return emps;
        }
    }
}
