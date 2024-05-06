using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnToLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(5, transform.position.y, transform.position.z);
        }
    }
}
