using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;

    public string bestPlayerName;
    public string bestPlayerScore;

    private void Awake() //Called when an object is created.
    {
        //Singleton pattern. If an instance already exists the new one is destroyed and the script exits.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestPlayer();
    }
    
    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public string bestScore;
    }

    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayerName;
        data.bestScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestplayer.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/bestplayer.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestPlayer;
            bestPlayerScore = data.bestScore;
        }
    }
}
