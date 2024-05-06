using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuwafuwa : MonoBehaviour
{
    public GameMaster master;

    private float prevSpeed = 0.0f;
    private float amplitude; // �U��
    private float frequency; // ���g��
    private Vector3 initialPosition;

    // �V�[���ǂݍ��ݎ� RANDOM_SCORE ���� 1 �̊m���� Lead ����񂪍���������
    private float randomBuff;
    private const float BUFF_VALUE = 20.0f;

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

        randomBuff = master.isCrashed ? BUFF_VALUE : 1.0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!master.hasFailed)
        {
            if (!master.hasCleared)
            {
                amplitude = master.movementSpeed * COEF_AMP * randomBuff;
                frequency = master.movementSpeed * COEF_FREQ * randomBuff;

                // �ӂ�ӂ킳����
                float yPos = initialPosition.y + amplitude * Mathf.Sin(2 * Mathf.PI * frequency);

                // INPUT �ɉ����� X �ʒu��ύX����
                float xPos;
                if (master.isControlled)
                {
                    if (master.inputPositionX >= Screen.width / 2)
                    {
                        xPos = Mathf.Min(transform.position.x + master.movementSpeed, X_MAX);
                    }
                    else if (master.inputPositionX < Screen.width / 2)
                    {
                        xPos = Mathf.Max(transform.position.x - 0.01f, initialPosition.x);
                    }
                    else
                    {
                        xPos = transform.position.x;
                    }
                }
                else
                {
                    xPos = transform.position.x;
                }

                transform.position = new Vector3(xPos, yPos, initialPosition.z);

                transform.rotation = transform.rotation * Quaternion.Euler(0.0f, 0.0f, -master.rotationSpeed);
            }
        }
    }
}
