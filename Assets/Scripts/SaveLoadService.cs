using System.IO;
using UnityEngine;

public static class SaveLoadService
{
    [System.Serializable]
    class SaveData
    {
        public string Name;
    }

    public static void SaveName(string text)
    {
        SaveData data = new SaveData();
        data.Name = text;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static string LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data.Name;
        }
        return "Name";
    }

    [System.Serializable]
    public class SaveScore
    {
        public int BestScore;
        public string Name;
    }

    public static void SaveBestScore(int score, string name)
    {
        SaveScore data = new SaveScore();
        data.BestScore = score;
        data.Name = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveBestScore.json", json);
    }

    public static SaveScore LoadBestScore()
    {
        string path = Application.persistentDataPath + "/saveBestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScore data = JsonUtility.FromJson<SaveScore>(json);

            return data;
        }
        return null;
    }
} 
