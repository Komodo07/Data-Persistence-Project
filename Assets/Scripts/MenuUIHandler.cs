using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject nameInput;

    public void StartNew()
    {
        if(nameInput.ToString() != null)
        {
            GameManager.Instance.playerName = nameInput.ToString();
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
