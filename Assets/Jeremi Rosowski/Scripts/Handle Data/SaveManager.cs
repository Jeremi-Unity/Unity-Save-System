// SaveManager.cs - file containing the implementation of the save manager:

using UnityEngine;

// The SaveManager class which manages saving and loading game data:
public class SaveManager
{
    private static SaveManager _instance; // singleton instance of the SaveManager
    private ISaveData _saveData; // instance of the ISaveData interface used for saving and loading data
    private string _gameVersion = "1.0"; // initial game version

    // Constructor for the SaveManager class which takes an ISaveData parameter:
    private SaveManager(ISaveData saveData)
    {
        _saveData = saveData;
    }

    // Singleton instance property for the SaveManager:
    public static SaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SaveManager(CreateSaveData());
            }
            return _instance;
        }
    }

    // Method for creating an instance of ISaveData based on the currently selected save format:
    private static ISaveData CreateSaveData()
    {
        ISaveDataFactory saveDataFactory = null;
        switch (Config.SaveFormat)
        {
            case SaveFormat.Json:
                saveDataFactory = new JsonSaveDataFactory();
                break;
            case SaveFormat.Binary:
                saveDataFactory = new BinarySaveDataFactory();
                break;
            default:
                throw new System.NotSupportedException("Unknown save format.");
        }
        return saveDataFactory.CreateSaveData();
    }

    // Method for saving data with the specified key and data object:
    public void Save(string key, object data)
    {
        _saveData.Save(key, data);
    }

    // Method for loading data with the specified key and returning it as type T:
    public T Load<T>(string key)
    {
        return _saveData.Load<T>(key);
    }  
  

    // Method for setting the current save format:
    public void SetSaveFormat(SaveFormat format)
    {
        Config.SaveFormat = format;
        _saveData = CreateSaveData();
    }

    // Method for getting the save path:
    public string GetSavePath()
    {
        return Application.persistentDataPath;
    }

    // Methods for handling button clicks to increase or decrease the game version:
    public void IncreaseVersion()
    {
        float version = float.Parse(_gameVersion);
        version += 0.1f;
        _gameVersion = version.ToString("0.0");
        Debug.Log("Game version increased to: " + _gameVersion);
    }
    // Methods for handling button clicks to increase or decrease the game version:
    public void DecreaseVersion()
    {
        float version = float.Parse(_gameVersion);
        version -= 0.1f;
        _gameVersion = version.ToString("0.0");
        Debug.Log("Game version decreased to: " + _gameVersion);
    }
}