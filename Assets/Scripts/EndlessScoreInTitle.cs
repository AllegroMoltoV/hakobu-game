using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessScoreInTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("Endless High Score");
        string score = highScore.ToString();
        if (highScore == 0)
        {
            score = "-";
        }

        GetComponent<TextMeshProUGUI>().text = "ENDLESS HIGH SCORE: " + score;

    }
}
