
using System;
using UnityEngine;
using System.IO;

public class SaveData : MonoBehaviour
{

    public static SaveData Instance;


    public PlayerData playerSaveData;

    public string inputName;

    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null) { Destroy(this); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSave();
    }


    public void Save(string name, int score)
    {
        PlayerData newSave = new PlayerData();
        newSave.playerName = name;
        newSave.highScore = score;

        string json = JsonUtility.ToJson(newSave);
        File.WriteAllText(Application.persistentDataPath + "saveFile.json", json);
    }
    public void LoadSave()
    {
        string file = Application.persistentDataPath + "saveFile.json";
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerSaveData = data;

            highScoreName = data.playerName;
            highScore = data.highScore;
        }
    }
}
[Serializable]
public class PlayerData
{
    public string playerName;
    public int highScore;
}
