using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAtCleared : MonoBehaviour
{
    public GameMaster master;

    private bool hasShowed;

    // Start is called before the first frame update
    void Start()
    {
        hasShowed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasShowed && master.hasCleared)
        {
            transform.position = new Vector3(0, transform.position.y, 0);
            hasShowed = true;
        }
    }
}
