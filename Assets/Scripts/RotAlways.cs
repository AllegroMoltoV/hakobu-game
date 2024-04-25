using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotAlways : MonoBehaviour
{
    const float ROTATION_SPEED = 40.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // オブジェクトを回転させる
        transform.Rotate(new Vector3(0, 0, ROTATION_SPEED) * Time.deltaTime);
    }
}
