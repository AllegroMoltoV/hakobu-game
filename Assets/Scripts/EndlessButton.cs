using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessButton : MonoBehaviour
{
    public const string sceneName = "Endless";
    public DebugCommand debugCommand;
    public bool isForceEnabled;
    public AudioClip bell;
    AudioSource audioSource;

    void Awake()
    {
        isForceEnabled = false;
        audioSource = GetComponent<AudioSource>();
        float highScore = PlayerPrefs.GetInt("High Score");
        string score = highScore.ToString();
        if (highScore < 100)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    void FixedUpdate()
    {
        if (debugCommand.counter == 9 && !isForceEnabled)
        {
            isForceEnabled = true;
            audioSource.PlayOneShot(bell);
            GetComponent<Button>().interactable = true;
        }
    }

    public void LoadScene()
    {
        // シーンをロードする
        SceneManager.LoadScene(sceneName);
    }
}