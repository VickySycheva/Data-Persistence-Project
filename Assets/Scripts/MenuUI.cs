using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField Name;
    public TextMeshProUGUI BestScore;

    public void Start()
    {
        var data = SaveLoadService.LoadBestScore();
        if(data != null )
        BestScore.text = $"Best score: {data.BestScore} {data.Name}";
    }

    public void StartNew()
    {
        SaveLoadService.SaveName(Name.text);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Aplication.Quit();
#endif
    }

   
}
