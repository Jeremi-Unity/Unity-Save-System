
# Unity Save System
Unity version: 2021.3.7f1
<br>Unity Save System - https://youtu.be/fMF-i36Uifc     (27/04/2023)


<code>1.BinarySaveData.cs:</code><br><br> This script is responsible for saving and loading data in binary format. It implements the ISaveData interface and contains                                    <br><br> the methods for saving and loading data using BinaryFormatter.<br>
                
<code>2.CloudService.cs:</code>
                <br><br>This script simulates cloud storage and allows saving and loading player name data to and from it. It is used in MySaveLoadScript to save and                   <br><br>load the player name data to the cloud.<br>

<code>3.Config.cs:</code>
                <br><br>This script contains the configuration of the save system. It defines the default save format and the initial game version.<br>

<code>4.JsonSaveData.cs:</code>
                <br><br>This script is responsible for saving and loading data in JSON format. It implements the ISaveData interface and contains the methods for 
                <br><br>saving and loading data using Newtonsoft.Json.<br>


<code>5.SaveData.cs:</code>
                <br><br>This script contains the interfaces and abstract classes for the save system. It defines the ISaveData and ISaveDataFactory interfaces and the                 <br><br>SaveDataFactoryBase abstract class.<br>

<code>6.SaveManager.cs:</code>
                <br><br>This script manages the save system. It is responsible for creating the appropriate save data object based on the selected save format, and                     <br><br>provides methods for saving and loading data. It also provides methods for saving data to the cloud and managing the game version.<br>

<code>7.MySaveLoadScript.cs:</code>
                <br><br>This script is responsible for managing the UI for saving and loading the player data. 
                <br><br>It uses SaveManager and CloudService to save and load data.<br>

<code>8.SaveFormatSelector.cs:</code>
                <br><br>This script is responsible for managing the UI for selecting the save format. It provides buttons to switch between JSON and binary formats and                 <br><br>saves the selected format to player prefs.<br>
