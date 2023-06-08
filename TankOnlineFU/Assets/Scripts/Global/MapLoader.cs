using System.IO;
using Entities;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public static Map Map;
    public static void LoadMap(string level)
    {
        string levelJsonPath = Application.dataPath + "/Data/" + level + ".json";
        if (File.Exists(levelJsonPath))
        {
            string json = File.ReadAllText(levelJsonPath);
            Map = JsonUtility.FromJson<Map>(json);
            GameSettings.Map = Map;
        }

    }
    public static void LoadCreatedLevels()
    {
        string savePath = Application.dataPath + "/Data/";
        string[] fileNames = Directory.GetFiles(savePath);
        foreach (string fileName in fileNames)
        {
            if (fileName.Contains("create"))
            {
                GameSettings.createdLevel++;
            }
        }
    }
}
