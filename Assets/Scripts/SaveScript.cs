using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveScript
{

    public static void SavePlayer(PlayerScript playerScript, int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player" + saveNumber + ".fun";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(playerScript);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
        Debug.Log("Game saved!");
    }

    public static SaveData LoadPlayer(int saveNumber)
    {
        string path = Application.persistentDataPath + "/player" + saveNumber + ".fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(fileStream) as SaveData;
            fileStream.Close();
            return data;
        }
        else
        {
            Debug.Log("SavePath not found in " + path);
            return null;
        }
    }

    public static void DeleteSave(int saveNumber)
    {
        string path = Application.persistentDataPath + "/player" + saveNumber + ".fun";
        try
        {
            File.Delete(path);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
