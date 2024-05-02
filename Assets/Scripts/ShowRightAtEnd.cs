using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRightAtEnd : MonoBehaviour
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
        if (!hasShowed && (master.hasCleared || master.hasFailed))
        {
            transform.position = new Vector3(Screen.width - Screen.width / 8.0f, transform.position.y, 0);
            hasShowed = true;
        }
    }
}
