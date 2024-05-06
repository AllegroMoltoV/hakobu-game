using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGameMaster : GameMaster
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!HasTerminated())
        {
            scoreFloat += movementSpeed;
            score = (int)(scoreFloat * 10);
            rotationSpeed = 0.0f;

            // Ž¸”s”»’è
            if (molto.transform.position.y < -10)
            {
                TerminateGame();
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

    private void TerminateGame()
    {
        Destroy(this.molto);
        float highScore = PlayerPrefs.GetInt("Endless High Score");
        if (this.score > highScore)
        {
            PlayerPrefs.SetInt("Endless High Score", this.score);
        }
        this.hasFailed = true;
    }

    private bool HasTerminated()
    {
        return hasFailed;
    }
}
