using System;
using Entities;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine;
using System.IO;
using System.Xml.Linq;

public class MapSaver
{
    public static Map Map;
    public static void Save()
    {
        Map = GameSettings.Map;
        string savePath = Application.dataPath + "/Data/";
        //string[] fileNames = Directory.GetFiles(savePath);
        //foreach (string fileName in fileNames)
        //{
        //    if (fileName.Contains("create"))
        //    {
        //        levelCount++;
        //    }
        //}
        string levelPath = savePath + "Level_" + ++GameSettings.createdLevel + "_create.json";
        string json = JsonUtility.ToJson(Map);

        // Save JSON to a file
        File.WriteAllText(levelPath, json);


        //string levelJsonPath = Application.dataPath + "/Data/" + level + ".json";
        //if (File.Exists(levelJsonPath))
        //{
        //    string json = File.ReadAllText(levelJsonPath);
        //    Map = JsonUtility.FromJson<Map>(json);
        //    GameSettings.Map = Map;
        //}
    }
}
