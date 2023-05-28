using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = "Create Level Data")]
public class LevelManager : ScriptableObject
{
    [SerializeField] private string[] levels;
    public string GetNextLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        for (int i = 0; i < levels.Length - 1; i++)
        {
            if (levels[i] == curScene.name)
            {
                return levels[++i];
            }
        }
        return string.Empty;
    }
}
