using System;
using Entities;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine;
using System.IO;
using System.Xml.Linq;

public class MapSaver
{
    public static Map Map;
    public static async void Save()
    {
        Map = GameSettings.Map;
        string savePath = Application.dataPath + "/Data/";
        string levelPath = savePath + "Level_" + ++GameSettings.createdLevel + "_create.json";
        string json = JsonUtility.ToJson(Map);

        // Save JSON to a file
        await File.WriteAllTextAsync(levelPath, json);
    }
}
