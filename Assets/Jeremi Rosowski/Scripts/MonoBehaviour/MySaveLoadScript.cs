// MySaveLoadScript.cs - file containing the implementation of the save and load functionality:
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

// MySaveLoadScript class which implements the save and load functionality:
public class MySaveLoadScript : MonoBehaviour
{
    // reference to the player name input field in the UI:
    public TMP_InputField PlayerNameInputField;
    // reference to the save to cloud button in the UI:
    public Button SaveToCloudButton;
    // reference to the load from cloud button in the UI:
    public Button LoadFromCloudButton;
    // reference to the increase version button in the UI:
    public Button IncreaseVersionButton;
    // reference to the decrease version button in the UI:
    public Button DecreaseVersionButton;
    // reference to the save text in the UI:
    [SerializeField] private TMP_Text _saveText;
    // reference to the version text in the UI:
    [SerializeField] private TMP_Text _versionText;

    private CloudService _cloudService;

    // Start method which is called when the script is initialized:
    private void Start()
    {
        // create a new instance of the cloud service class and pass this script as a parameter:
        _cloudService = new CloudService(this);

        // add event listeners to the UI buttons:
        SaveToCloudButton.onClick.AddListener(_cloudService.SaveToCloud);
        LoadFromCloudButton.onClick.AddListener(_cloudService.LoadFromCloud);
        IncreaseVersionButton.onClick.AddListener(IncreaseVersion);
        DecreaseVersionButton.onClick.AddListener(DecreaseVersion);

        // set the save text to inactive:
        _saveText.gameObject.SetActive(false);
        // set the version text to the current game version:
        _versionText.text = "Game version: " + Config.GameVersion;
    }

    // SaveGame method which saves the player name and game version to file:
    public void SaveGame()
    {
        // get the player name from the UI input field:
        string playerName = PlayerNameInputField.text;
        // create a new instance of the MySaveData class with the player name and game version:
        MySaveData saveData = new MySaveData(playerName, Config.GameVersion);
        // serialize the save data object to JSON:
        string saveDataJson = JsonConvert.SerializeObject(saveData);
        // save the JSON string to file using the SaveManager class:
        SaveManager.Instance.Save("SaveData", saveDataJson);
        // set the save text to active and display the save path:
        _saveText.gameObject.SetActive(true);
        _saveText.text = "Game saved to: " + SaveManager.Instance.GetSavePath();

        // save the game to the cloud using the cloud service class:
        _cloudService.SaveToCloud();
    }

    // LoadGame method which loads the player name and game version from file:
    public void LoadGame()
    {
        // load the save data JSON string from file using the SaveManager class:
        string saveDataJson = SaveManager.Instance.Load<string>("SaveData");
        // if the JSON string is not empty:
        if (!string.IsNullOrEmpty(saveDataJson))
        {
            // deserialize the JSON string to a MySaveData object:
            MySaveData saveData = JsonConvert.DeserializeObject<MySaveData>(saveDataJson);
            // set the player name in the UI input field:
            PlayerNameInputField.text = saveData.playerName;

            // check if the saved game version is the same as the current game version:
            if (saveData.version != Config.GameVersion)
            {
                // log a warning if the saved game version is different

                Debug.LogWarning("Trying to load save data from a different game version. Current game version: " + Config.GameVersion + ", Save data version: " + saveData.version);
            }
        }
    }

    private void IncreaseVersion()
    {
        Config.GameVersion++;
         _versionText.text = "Game version: " + Config.GameVersion; // dodana linia kodu
        Debug.Log("Game version increased to " + Config.GameVersion);
    }

    private void DecreaseVersion()
    {
        Config.GameVersion--;
        _versionText.text = "Game version: " + Config.GameVersion; // dodana linia kodu
        Debug.Log("Game version decreased to " + Config.GameVersion);
    }
}

public class MySaveData
{
    public string playerName;
    public int version;

    public MySaveData(string playerName, int version)
    {
        this.playerName = playerName;
        this.version = version;
    }
}