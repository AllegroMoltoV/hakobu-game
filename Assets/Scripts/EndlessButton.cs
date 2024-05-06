using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessButton : MonoBehaviour
{
    public const string sceneName = "Endless";

    void Awake()
    {
        float highScore = PlayerPrefs.GetInt("High Score");
        string score = highScore.ToString();
        if (highScore < 100)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void LoadScene()
    {
        // シーンをロードする
        SceneManager.LoadScene(sceneName);
    }
}