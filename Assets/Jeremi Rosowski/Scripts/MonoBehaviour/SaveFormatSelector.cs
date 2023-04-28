// SaveFormatSelector.cs - script responsible for allowing the player to choose the save data format (binary or JSON):
using UnityEngine;
using UnityEngine.UI;

public class SaveFormatSelector : MonoBehaviour
{   
    [SerializeField] public GameObject JsonFormatInfo = null;
    [SerializeField] public GameObject BinaryFormatInfo = null;
    public Button jsonButton;
    public Button binaryButton;

    // Start method is called on the frame when a script is enabled just before any of the Update methods are called the first time:
    private void Start()
    {
        // load the previously selected save format from player prefs:
        if (PlayerPrefs.HasKey("SaveFormat"))
        {
            string saveFormat = PlayerPrefs.GetString("SaveFormat");
            if (saveFormat == "json")
            {
                SetJsonFormat(); // set the JSON format if it was previously selected
            }
            else if (saveFormat == "binary")
            {
                SetBinaryFormat(); // set the binary format if it was previously selected
            }
        }
        else
        {
            SetJsonFormat(); // set the default save format to JSON if no save format was previously selected
        }
    }

    // SetJsonFormat method is called when the JSON button is clicked:
    public void SetJsonFormat()
    {   
        // deactivate the binary format info panel:
        if(BinaryFormatInfo.activeSelf)
        {
            BinaryFormatInfo.SetActive(false);
        }
        // activate the JSON format info panel:
        JsonFormatInfo.SetActive(true);
        // set the save format to JSON:
        SaveManager.Instance.SetSaveFormat(SaveFormat.Json);
        // save the selected format in player prefs:
        PlayerPrefs.SetString("SaveFormat", "json");
    }

    // SetBinaryFormat method is called when the binary button is clicked:
    public void SetBinaryFormat()
    {   
        // deactivate the JSON format info panel:
        if(JsonFormatInfo.activeSelf)
        {
            JsonFormatInfo.SetActive(false);
        }
        // activate the binary format info panel:
        BinaryFormatInfo.SetActive(true);
        // set the save format to binary:
        SaveManager.Instance.SetSaveFormat(SaveFormat.Binary);
        // save the selected format in player prefs:
        PlayerPrefs.SetString("SaveFormat", "binary");
    }
}
