using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScore : MonoBehaviour
{
    public GameMaster master;

    private TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        textMeshProUGUI.text = "Score: " + master.score.ToString() + "\nTime: " + master.time.ToString("F1");
    }
}
