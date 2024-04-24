using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool hasCleared;
    public bool hasFailed;

    public float time;
    public int score;

    public float movementSpeed;
    public float rotationSpeed;

    public GameObject molto;

    private float scoreFloat;
    private bool isControlled;

    private const uint SCORE_MAX = 100;
    private const float DELTA = 0.0001f;


    // Start is called before the first frame update
    void Start()
    {
        hasCleared = false;
        hasFailed = false;

        time = 0.0F;
        scoreFloat = 0.0f;
        score = 0;

        movementSpeed = 0.001f;
        rotationSpeed = 0.0f;

        isControlled = false;

        molto = GameObject.Find("molto");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasFailed)
        {
            if (molto.transform.position.y < -10)
            {
                hasFailed = true;
                Destroy(molto);
                float highScore = PlayerPrefs.GetInt("High Score");
                if (score >  highScore)
                {
                    PlayerPrefs.SetInt("High Score", score);
                }
            }

            if (!hasCleared)
            {
                time += Time.deltaTime;
                scoreFloat += movementSpeed;
                score = (int)(scoreFloat * 10);
                rotationSpeed = 0.0f;

                if (score == SCORE_MAX)
                {
                    float highScore = PlayerPrefs.GetInt("High Score");
                    if (score > highScore)
                    {
                        PlayerPrefs.SetInt("High Score", score);
                    }

                    float clearTime = PlayerPrefs.GetFloat("Clear Time");
                    if (clearTime == 0 || time  < clearTime)
                    {
                        PlayerPrefs.SetFloat("Clear Time",  time);
                    }

                    hasCleared = true;
                }
            }
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                isControlled = true;
            } else {
                isControlled = false;
            }
#else
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    isControlled = true;
                }
            }

            if (isControlled)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    {
                        isControlled = false;
                    }
                }
                else
                {
                    isControlled = false;
                }
            }

#endif // UNITY_EDITOR

#if UNITY_EDITOR
            if (isControlled) {
                if (Input.mousePosition.x >= Screen.width / 2)
                {
                    movementSpeed += DELTA;
                    rotationSpeed = 1.0f;
                }
                else if (Input.mousePosition.x < Screen.width / 2)
                {
                    movementSpeed = Mathf.Max(movementSpeed - DELTA, 0);
                    rotationSpeed = -1.0f;
                }
            }
#else
            if (isControlled)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.position.x >= Screen.width / 2)
                    {
                        movementSpeed += DELTA;
                        rotationSpeed = 1.0f;
                    }
                    else if (touch.position.x < Screen.width / 2)
                    {
                        movementSpeed = Mathf.Max(movementSpeed - DELTA, 0);
                        rotationSpeed = -1.0f;
                    }
                }
            }
#endif
        }
    }
}
