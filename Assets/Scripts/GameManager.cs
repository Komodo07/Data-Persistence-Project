using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;

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
    }    
}
