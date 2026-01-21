using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/save.json";

    public static void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static GameData Load()
    {
        if (!File.Exists(path))
            return new GameData();

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<GameData>(json);
    }
}
