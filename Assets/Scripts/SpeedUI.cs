using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUI : MonoBehaviour
{
    public GameMaster master;

    private float MAX_SPEED = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (master.isCrashed && master.isControlled)
        {
            transform.Rotate(0.0f, 0.0f, -20.0f);
        } else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90 - master.movementSpeed / MAX_SPEED * 180);
        }
    }
}
