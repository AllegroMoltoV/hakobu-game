using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public GameMaster master;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!master.hasFailed)
        {
            if (!master.hasCleared)
            {
                // オブジェクトを左に移動させる
                transform.position = transform.position + new Vector3(-1.0F, 0, 0) * master.movementSpeed;
            }
        }
    }
}
