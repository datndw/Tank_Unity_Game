using System.IO;
using Entities;
using UnityEngine;

public class MapLoader
{
    public static void LoadMap(string level)
    {
        string levelJsonPath = Application.dataPath + "/Data/" + level + ".json";
        if (File.Exists(levelJsonPath))
        {
            string json = File.ReadAllText(levelJsonPath);
            Debug.Log(json);
            Map map = JsonUtility.FromJson<Map>(json);
        }

    }
}
