using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndlessStartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = GetComponent<Button>();

        if (PlayerPrefs.GetFloat("High Score") < 100) {
            b.interactable = false;
        } 
        else
        {
            b.interactable = true;
        }
        
    }
}
