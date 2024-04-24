using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSprite : MonoBehaviour
{
    public GameMaster master;
    public Sprite newSprite;

    private bool hasSwitched;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        hasSwitched = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (master.hasFailed && !hasSwitched)
        {
            spriteRenderer.sprite = newSprite;
            hasSwitched = true;
        }
    }
}
