using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProgressBarController : MonoBehaviour
{
    Image progressBar;
    bool updateProgress;
    private float waitTime;

    private void Awake()
    {
        progressBar = GetComponent<Image>();
    }

    private void OnEnable()
    {
        InputManager.im_Instance.OnTouchBeganEvent += EnableProgress;
        InputManager.im_Instance.OnTouchEndedEvent += DisableProgress;
    }

    private void OnDisable()
    {
        if (InputManager.im_Instance != null)
        {
            InputManager.im_Instance.OnTouchBeganEvent -= EnableProgress;
            InputManager.im_Instance.OnTouchEndedEvent -= DisableProgress;
        }
    }

    private void Start()
    {
        waitTime = InputManager.im_Instance.maxDelay;
        ShowBar(false);
    }

    void UpdateProgressBar()
    {
        progressBar.fillAmount -= 1f / waitTime * Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (updateProgress)
        {
            UpdateProgressBar();
        }
	}

    void ShowBar(bool show)
    {
        progressBar.fillAmount = (show ? 1f : 0f);
    }

    void DisableProgress()
    {
        ShowBar(false);
        updateProgress = false;
    }

    void EnableProgress()
    {
        ShowBar(true);
        updateProgress = true;
    }
}
