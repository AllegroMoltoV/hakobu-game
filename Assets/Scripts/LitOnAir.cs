using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitOnAir : MonoBehaviour
{
    public GameMaster master;

    private SpriteRenderer sprite;
    private bool hasColored;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, 1);
        hasColored = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (master.hasCleared && !hasColored)
        {
            sprite.color = new Color(1, 0, 0, 1); 
            hasColored = true;
        }
    }
}
