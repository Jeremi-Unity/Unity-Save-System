// Config.cs - file containing the Config static class
public static class Config
{
public static SaveFormat SaveFormat = SaveFormat.Json; // save format is set to JSON by default
public static int GameVersion = 1; // game version is set to 1 by default
}
// SaveFormat enum which represents the possible save formats
public enum SaveFormat
{
Json,
Binary
}