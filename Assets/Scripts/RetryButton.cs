using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public const string sceneName = "Main";

    public void LoadScene()
    {
        // シーンをロードする
        SceneManager.LoadScene(sceneName);
    }
}