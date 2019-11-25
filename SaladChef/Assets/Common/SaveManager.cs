using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
class GameData
{
    public Dictionary<string, object> saveData;
    public GameData()
    {
        saveData = new Dictionary<string, object>();
    }
}
public class SaveManager
{
    const string fileName = "/saladChefGame.data";
    private static SaveManager  mInstance;
    private GameData gameData = new GameData();

    static SaveManager pInstance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new SaveManager();
                mInstance.LoadDataFromFile();
            }
            return mInstance;
        }
    }


  
    public static void ClearData()
    {
        pInstance.gameData.saveData.Clear();
        CreateData();
    }

 
    public static T LoadData<T>(string key)
    {
        return (T)pInstance.gameData.saveData[key];
    }

   
    public static bool HasKey<T>(string key)
    {
        if (pInstance.gameData.saveData.ContainsKey(key))
            return true;

        return false;
    }

    
    public static void SaveData<T>(string key, T value)
    {
        if (pInstance.gameData.saveData.ContainsKey(key))
            pInstance.gameData.saveData[key] = value;
        else
            pInstance.gameData.saveData.Add(key, value);
    }

  
    public static void CreateData()
    {
        using (FileStream file = File.Create(Application.persistentDataPath + fileName))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, pInstance.gameData);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
    }

   
    private void LoadDataFromFile()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            FileStream file = null;

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
                gameData = (GameData)bf.Deserialize(file);

            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }
        else
            Debug.Log("No GameData Loaded");
    }
}

