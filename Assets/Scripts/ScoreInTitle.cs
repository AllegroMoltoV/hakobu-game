using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreInTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float highScore = PlayerPrefs.GetInt("High Score");
        string score = highScore.ToString();
        if (highScore == 0)
        {
            score = "-";
        }

        float clearTime = PlayerPrefs.GetFloat("Clear Time");
        string time = clearTime.ToString("F1");
        if (clearTime == 0)
        {
            time = "-";
        }

        GetComponent<TextMeshProUGUI>().text = "HIGH SCORE: " + score + "\nCLEAR TIME: " + time;

    }
}
