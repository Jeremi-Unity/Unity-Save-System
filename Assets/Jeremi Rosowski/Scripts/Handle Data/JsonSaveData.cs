using UnityEngine;
using System.IO;
using Newtonsoft.Json;

//JsonSaveData.cs - file containing the implementation of the ISaveData interface for JSON format:
public class JsonSaveData : ISaveData
{
    // Save method which saves the given data object with the specified key in JSON format:
    public void Save(string key, object data)
    {
        // Serialize the data object to a JSON string:
        string json = JsonConvert.SerializeObject(data);
        // Construct the save path by appending .json extension to the key:
        string path = Path.Combine(Application.persistentDataPath, key + ".json");
        // Write the JSON string to the file:
        File.WriteAllText(path, json);
    }

    // Load method which loads the data with the specified key in JSON format:
    public T Load<T>(string key)
    {
        // Construct the save path by appending .json extension to the key:
        string path = Path.Combine(Application.persistentDataPath, key + ".json");
        // Check if the file exists at the path:
        if (!File.Exists(path))
        {
            // Return the default value of type T if the file does not exist:
            return default(T);
        }
        // Read the contents of the file as a JSON string:
        string json = File.ReadAllText(path);
        // Deserialize the JSON string and return the data object:
        return JsonConvert.DeserializeObject<T>(json);
    }
}

// JsonSaveDataFactory class which inherits from the SaveDataFactoryBase class for JSON save data:
public class JsonSaveDataFactory : SaveDataFactoryBase<JsonSaveData>
{
}