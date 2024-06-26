using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public bool hasCleared;
    public bool hasFailed;
    public bool isCrashed;

    public float time;
    public int score;

    public float movementSpeed;
    public float rotationSpeed;

    public GameObject molto;

    public float scoreFloat;
    public bool isControlled;
    public float inputPositionX;

    public const uint SCORE_MAX = 100;
    public const float DELTA = 0.0001f;
    public const int RANDOM_SCORE = 256;

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

        if (Random.Range(0, RANDOM_SCORE) == 0)
        {
            isCrashed = true;
        }
        else
        {
            isCrashed = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!HasTerminated())
        {
            time += Time.deltaTime;
            scoreFloat += movementSpeed;
            score = (int)(scoreFloat * 10);
            rotationSpeed = 0.0f;

            // ���s����
            if (molto.transform.position.y < -10)
            {
                TerminateGame(false);
            }

            // ��������
            if (score == SCORE_MAX)
            {
                float clearTime = PlayerPrefs.GetFloat("Clear Time");
                if (clearTime == 0 || time < clearTime)
                {
                    PlayerPrefs.SetFloat("Clear Time", time);
                }

                TerminateGame(true);
            }

#if UNITY_EDITOR || UNITY_WEBGL
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

#if UNITY_EDITOR || UNITY_WEBGL
            if (isControlled) {
                inputPositionX = Input.mousePosition.x;
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
                    inputPositionX = touch.position.x;
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

    private void TerminateGame(bool isCleared)
    {
        Destroy(this.molto);
        float highScore = PlayerPrefs.GetInt("High Score");
        if (this.score > highScore)
        {
            PlayerPrefs.SetInt("High Score", this.score);
        }

        if (isCleared)
        {
            this.hasCleared = true;
        }
        else
        {
            this.hasFailed = true;
        }
    }

    private bool HasTerminated()
    {
        return hasFailed || hasCleared;
    }
}
