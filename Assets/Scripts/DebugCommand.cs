using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCommand : MonoBehaviour
{
    public enum Command
    {
        NONE = 0,
        UE,
        SHITA,
        HIDARI,
        MIGI,
        B,
        A,
    }

    public int counter;
    public bool isEndlessButtonForceEnabled;
    public bool isPressed;
    public bool wasPressedPrevious;
    public bool isTriggered;

    public void IncrementCounter()
    {
        counter++;
    }

    // Start is called before the first frame update
    void Awake()
    {
        counter = 0;
        isPressed = false;
        wasPressedPrevious = false;
        isTriggered = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

#if UNITY_EDITOR || UNITY_WEBGL
            if (Input.GetMouseButton(0))
            {
                isPressed = true;
            } else {
                isPressed = false;
            }
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isPressed = true;
            }
        }

        if (isPressed)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isPressed = false;
                }
            }
            else
            {
                isPressed = false;
            }
        }

#endif // UNITY_EDITOR

        isTriggered = isPressed && !wasPressedPrevious;
        wasPressedPrevious = isPressed;

        if (isTriggered)
        {
            #if UNITY_EDITOR || UNITY_WEBGL
            float inputPositionX = Input.mousePosition.x;
            float inputPositionY = Input.mousePosition.y;
            #else
            float inputPositionX = 0.0f;
            float inputPositionY = 0.0f;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                inputPositionX = touch.position.x;
                inputPositionY = touch.position.y;
            }
            #endif

            Command command = Command.NONE;

            if (inputPositionX > Screen.width / 3 &&
                inputPositionX < Screen.width * 2 / 3)
            {
                if (inputPositionY < Screen.height / 3)
                {
                    command = Command.SHITA;
                }
                else if (inputPositionY > Screen.height * 2 / 3)
                {
                    command = Command.UE;
                }
            }
            else if (inputPositionY > Screen.height / 3 &&
                inputPositionX < Screen.height * 2 / 3)
            {
                if (inputPositionX < Screen.width / 3)
                {
                    command = Command.HIDARI;
                }
                else if (inputPositionX > Screen.width * 2 / 3)
                {
                    command = Command.MIGI;
                }
            }

            switch (counter)
            {
                case 0:
                case 1:
                    {
                        if (command == Command.UE)
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 0;
                        }
                        break;
                    }
                case 2:
                case 3:
                    {
                        if (command == Command.SHITA)
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 0;
                        }
                        break;
                    }
                case 4:
                case 6:
                    {
                        if (command == Command.HIDARI)
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 0;
                        }
                        break;
                    }
                case 5:
                case 7:
                    {
                        if (command == Command.MIGI)
                        {
                            counter++;
                        }
                        else
                        {
                            counter = 0;
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
