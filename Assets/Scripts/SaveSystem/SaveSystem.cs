using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save(Progress progress)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/progress.yo";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        ProgressDate progressDate = new ProgressDate(progress);
        binaryFormatter.Serialize(fileStream, progressDate);
        fileStream.Close();
    }

    public static ProgressDate Load()
    {
        string path = Application.persistentDataPath + "/progress.yo";
        if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            ProgressDate progressDate = binaryFormatter.Deserialize(fileStream) as ProgressDate;
            fileStream.Close();
            return progressDate;
        }
        else
        {
            Debug.Log("NO File");
            return null;
        }
    }

    public static void DeliteFile()
    {
        File.Delete(Application.persistentDataPath + "/progress.yo");
    }
}
