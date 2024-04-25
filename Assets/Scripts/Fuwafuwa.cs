using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuwafuwa : MonoBehaviour
{
    public GameMaster master;

    private float prevSpeed = 0.0f;
    private float amplitude; // U•
    private float frequency; // Žü”g”
    private Vector3 initialPosition;

    private const float X_MAX = 1.0F;
    private const float COEF_AMP = 20.0f;
    private const float COEF_FREQ = 400.0f;
    private const float COEF_ROTATION = 4000.0f;

    // Start is called before the first frame update
    void Start()
    {
        amplitude = 0.1f;
        frequency = 0.1f;
        initialPosition = transform.position;
        prevSpeed = master.movementSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!master.hasFailed)
        {
            if (!master.hasCleared) {
                amplitude = master.movementSpeed * COEF_AMP;
                frequency = master.movementSpeed * COEF_FREQ;

                // ‚Ó‚í‚Ó‚í‚³‚¹‚é
                float yPos = initialPosition.y + amplitude * Mathf.Sin(2 * Mathf.PI * frequency);

                // INPUT ‚É‰ž‚¶‚Ä X ˆÊ’u‚ð•ÏX‚·‚é
                float xPos;
                if (Input.GetMouseButton(0))
                {
                    if (Input.mousePosition.x >= Screen.width / 2)
                    {
                        xPos = Mathf.Min(transform.position.x + master.movementSpeed, X_MAX);
                    }
                    else if (Input.mousePosition.x < Screen.width / 2)
                    {
                        xPos = Mathf.Max(transform.position.x - 0.01f, initialPosition.x);
                    } else
                    {
                        xPos = transform.position.x;
                    }
                } else
                {
                    xPos = transform.position.x;
                }

                transform.position = new Vector3(xPos, yPos, initialPosition.z);

                transform.rotation = transform.rotation * Quaternion.Euler(0.0f, 0.0f, -master.rotationSpeed);
            }
        }
    }
}
