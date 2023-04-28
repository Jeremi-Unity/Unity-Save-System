// SaveData.cs - file containing the interfaces and abstract classes for saving and loading data:

// Interface defining the methods for saving and loading data:
public interface ISaveData
{
    void Save(string key, object data);
    T Load<T>(string key);
}

// Interface defining a factory for creating instances of ISaveData:
public interface ISaveDataFactory
{
    ISaveData CreateSaveData();
}

// Abstract class implementing the ISaveDataFactory interface and constraining the generic parameter to be an ISaveData:
public abstract class SaveDataFactoryBase<T> : ISaveDataFactory where T : ISaveData, new()
{
    // Implementation of the CreateSaveData method which creates a new instance of the generic type T:
    public ISaveData CreateSaveData()
    {
        return new T();
    }
}

