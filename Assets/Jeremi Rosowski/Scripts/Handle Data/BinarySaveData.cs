// BinarySaveData.cs - file containing the implementation of the ISaveData interface for binary format:
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// BinarySaveData class which implements the ISaveData interface for saving/loading data in binary format:
public class BinarySaveData : ISaveData
{
    // Save method which saves the given data object with the specified key in binary format:
    public void Save(string key, object data)
    {
        // create a binary formatter object:
        BinaryFormatter formatter = new BinaryFormatter();
        // construct the save path by appending .bin extension to the key:
        string path = Path.Combine(Application.persistentDataPath, key + ".bin");
        // create a file stream and open it in create mode:
        FileStream stream = new FileStream(path, FileMode.Create);
        // serialize the data object and write it to the file:
        formatter.Serialize(stream, data);
        // close the file stream:
        stream.Close();
    }

    // Load method which loads the data with the specified key in binary format:
    public T Load<T>(string key)
    {
        // construct the save path by appending .bin extension to the key:
        string path = Path.Combine(Application.persistentDataPath, key + ".bin");
        // check if the file exists at the path:
        if (!File.Exists(path))
        {
            // return the default value of type T if the file does not exist:
            return default(T);
        }
        // create a binary formatter object:
        BinaryFormatter formatter = new BinaryFormatter();
        // create a file stream and open it in read mode:
        FileStream stream = new FileStream(path, FileMode.Open);
        // deserialize the data object and return it:
        T data = (T)formatter.Deserialize(stream);
        // close the file stream:
        stream.Close();
        // return the deserialized data object:
        return data;
    }
}

// BinarySaveDataFactory class which inherits from the SaveDataFactoryBase class for binary save data:
public class BinarySaveDataFactory : SaveDataFactoryBase<BinarySaveData>
{
}