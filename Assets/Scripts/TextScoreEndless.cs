using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScoreEndless : MonoBehaviour
{
    public GameMaster master;

    private TextMeshProUGUI textMeshProUGUI;
    private int highScore;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        highScore = PlayerPrefs.GetInt("Endless High Score");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textMeshProUGUI.text = "Score: " + master.score.ToString();

        if (master.score > highScore )
        {
            textMeshProUGUI.color = Color.red;
            textMeshProUGUI.fontStyle = FontStyles.Bold;
        }
    }
}
