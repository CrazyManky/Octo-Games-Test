using System;
using System.IO;
using UnityEngine;

namespace SaveAndLoads_Utility
{
    public class SaveHandler
    {
        public void Save<T>(T data)
        {
            string dataJSon = JsonUtility.ToJson(data, true);
            string path = Path.Combine(Application.persistentDataPath, $"{typeof(T)}.json");
            File.WriteAllText(path, dataJSon);
            Debug.Log("Saved " + path);
        }
    }


    //Mock данные, можно добавить Header атрибуты для более точечной загрузки данных
    [Serializable]
    public class SaveData
    {
        public int SceneIndex { get; set; }
        public int PlayerData { get; set; }
        public int GameData { get; set; }
    }

    [Serializable]
    public class GameSettings
    {
    }

    [Serializable]
    public class GameplayFlags
    {
    }
}