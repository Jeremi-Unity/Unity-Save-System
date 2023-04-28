/*
Documentation for Save System:

1.BinarySaveData.cs: This script is responsible for saving and loading data in binary format. It implements the ISaveData interface and contains the methods for saving and loading data using BinaryFormatter.


2.CloudService.cs: This script simulates cloud storage and allows saving and loading player name data to and from it. It is used in MySaveLoadScript to save and load the player name data to the cloud.


3.Config.cs: This script contains the configuration of the save system. It defines the default save format and the initial game version.


4.JsonSaveData.cs: This script is responsible for saving and loading data in JSON format. It implements the ISaveData interface and contains the methods for saving and loading data using Newtonsoft.Json.


5.SaveData.cs: This script contains the interfaces and abstract classes for the save system. It defines the ISaveData and ISaveDataFactory interfaces and the SaveDataFactoryBase abstract class.


6.SaveManager.cs: This script manages the save system. It is responsible for creating the appropriate save data object based on the selected save format, and provides methods for saving and loading data. It also provides methods for saving data to the cloud and managing the game version.


7.MySaveLoadScript.cs: This script is responsible for managing the UI for saving and loading the player data. It uses SaveManager and CloudService to save and load data.


8.SaveFormatSelector.cs: This script is responsible for managing the UI for selecting the save format. It provides buttons to switch between JSON and binary formats and saves the selected format to player prefs.

*/
