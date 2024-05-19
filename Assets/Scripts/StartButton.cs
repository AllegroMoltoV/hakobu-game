using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public const string sceneName = "Main";
    public DebugCommand debugCommand;

    public void LoadScene()
    {
        if (debugCommand.counter == 8)
        {
            debugCommand.IncrementCounter();
        }
        else
        {
            // シーンをロードする
            SceneManager.LoadScene(sceneName);
        }
    }
}