using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public Text bestScore;
    public GameObject nameInput;
    string playerName;

    public void Start()
    {
        bestScore.text = "Best Score: " + GameManager.Instance.bestPlayerName + " " + GameManager.Instance.bestPlayerScore;
    }

    public void StartNew()
    {
        playerName = nameInput.GetComponent<TMP_InputField>().text;

        if(playerName != null || playerName != "Enter your name")
        {
            GameManager.Instance.playerName = playerName;
        }

        SceneManager.LoadScene(1);        
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); //Command only works in a built application.
#endif
    }
}
