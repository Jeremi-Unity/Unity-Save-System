// CloudServiceMock.cs - file containing the CloudService class implementation for cloud saving
using UnityEngine;
using UnityEngine.UI;
// CloudService class which implements cloud saving
public class CloudService
{
private MySaveLoadScript _saveLoadScript;

public CloudService(MySaveLoadScript saveLoadScript)
{
    _saveLoadScript = saveLoadScript;
}

// SaveToCloud method which saves player name to PlayerPrefs
public void SaveToCloud()
{
    string playerName = _saveLoadScript.PlayerNameInputField.text;
    PlayerPrefs.SetString("PlayerName", playerName);
}

// LoadFromCloud method which loads player name from PlayerPrefs
public void LoadFromCloud()
{
    string playerNameFromCloud = PlayerPrefs.GetString("PlayerName");
    _saveLoadScript.PlayerNameInputField.text = playerNameFromCloud;
    Debug.Log("Game loaded from cloud: " + playerNameFromCloud);
}
}