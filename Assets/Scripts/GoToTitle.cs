using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
    public const string sceneName = "Title";

    public void LoadScene()
    {
        // �V�[�������[�h����
        SceneManager.LoadScene(sceneName);
    }
}