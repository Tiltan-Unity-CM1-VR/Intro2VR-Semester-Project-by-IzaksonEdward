using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public enum InputType
    {
        Touch,
        Joystick
    }

    [SerializeField] private InputType inputType;

    float timer;
    private bool isLongTouch = false;
    bool getInput = true;

    public float maxDelay = .5f;

    public delegate void TouchAction();
    public event TouchAction OnLongTouchEvent;
    public event TouchAction OnSingleTapEvent;

    public event TouchAction OnTouchBeganEvent;
    public event TouchAction OnTouchEndedEvent;

    public delegate void JoystickWheelAction(float x, float y);
    public event JoystickWheelAction OnJoystickWheelInputEvent;

    public delegate void JoystickButtonAction();
    public event JoystickButtonAction OnJoystickTriggerButton;

    private static InputManager im_instance;
    public static InputManager im_Instance
    {
        get
        {
            if (im_instance == null)
            {
                im_instance = FindObjectOfType<InputManager>();
            }
            return im_instance;

        }
    }


    private void Awake()
    {
        if (im_instance != null && im_instance != this)
        {
            Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (getInput)
        {
            if (inputType == InputType.Touch)
            {
                GetTouchInput();
            }
            else
            {
                GetJoystickInput();
            }
        }
    }

    public void SetInputType(InputType _inputType)
    {
        inputType = _inputType;
    }

    void GetJoystickInput()
    {
        float jHorizontal = Input.GetAxis("Horizontal");
        float jVertical = Input.GetAxis("Vertical");

        if (OnJoystickWheelInputEvent != null)
            OnJoystickWheelInputEvent(jHorizontal, jVertical);

        if (Input.GetKeyDown("joystick " + 1 + " button " + 7))
        {
            if (OnJoystickTriggerButton != null)
            {
                OnJoystickTriggerButton();
            }
        }
    }

    private void GetTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            TouchPhase touchPhase = touch.phase;

            switch (touchPhase)
            {
                case TouchPhase.Began:
                    if (OnTouchBeganEvent != null)
                    {
                        OnTouchBeganEvent();
                    }
                    break;

                case TouchPhase.Ended:
                    if (OnTouchEndedEvent != null)
                    {
                        OnTouchEndedEvent();
                    }

                    if (timer < maxDelay)
                    {
                        if (OnSingleTapEvent != null)
                        {
                            OnSingleTapEvent();
                        }
                    }
                    timer = 0;
                    isLongTouch = false;
                    break;

                default:
                    if (!isLongTouch)
                    {
                        timer += Time.deltaTime;
                        if (timer >= maxDelay)
                        {
                            if (OnLongTouchEvent != null)
                            {
                                OnLongTouchEvent();
                            }

                            isLongTouch = true;
                        }
                    }
                    break;
            }
        }
    }

    public void ListenToTouchInput(bool listen)
    {
        getInput = listen;

        if (!listen)
        {
            if (OnTouchEndedEvent != null)
            {
                OnTouchEndedEvent();
            }
        }

        timer = 0;
        isLongTouch = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        getInput = true;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
