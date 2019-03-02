using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timerRemaining;
    public TextMesh timerText;

    // Update is called once per frame
    void Update()
    {
        timerRemaining = timerRemaining - Time.deltaTime;
        timerText.text = Mathf.Floor(timerRemaining).ToString();

        if (timerRemaining<1)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
