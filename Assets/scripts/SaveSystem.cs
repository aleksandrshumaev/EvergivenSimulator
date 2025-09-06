
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save (gameLogic states)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+"/saves.huy";
        FileStream stream = new FileStream(path, FileMode.Create);
        gameData data=new gameData(states);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static gameData Load()
    {
        string path = Application.persistentDataPath+"/saves.huy";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream= new FileStream(path,FileMode.Open);
        gameData data=formatter.Deserialize(stream) as gameData;
        stream.Close();
        return data;
    }
}
