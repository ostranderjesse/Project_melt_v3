using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayerPerks(PlayerHealth HEALTHTOTAL)
    {
        //create binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.Perks";
        FileStream stream = new FileStream(path, FileMode.Create);
        //ready to write to file
        PlayerData data = new PlayerData(HEALTHTOTAL);
        //add data is now formatted
        //insert into file
        formatter.Serialize(stream, data);
        //close the stream
        stream.Close();
    }


    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.Perks";

        //check to see if file exists
        if(File.Exists(path))
        {
            //open binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            //read from the stream
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //close stream
            stream.Close();
            //return the data
            return data;

        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void WipeSavedData()
    {
        string path = Application.persistentDataPath + "/Player.Perks";

        if(File.Exists(path))
        {
            Debug.Log("File exists");
            File.Delete(path);
            Debug.Log("File deleted");

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        } else if( !File.Exists(path))
        {
            Debug.Log(" no file exists in: " + path);
        }
    }
}
