using System;
using System.IO;
using UnityEngine;

namespace SaveAndLoads_Utility
{
    public class LoadingHandler
    {
        
        public T LoadingData<T>() where T : class
        {
            string fullPath = Path.Combine(Application.persistentDataPath, $"{typeof(T)}.json");

            if (!File.Exists(fullPath))
                return null;

            try
            {
                string json = File.ReadAllText(fullPath);

                T data = JsonUtility.FromJson<T>(json);

                if (data == null)
                    return default;

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}