using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelperFunctions : MonoBehaviour
{
    public static void ChangeColor(Material _material,Color newColor)
    {
        _material.color = newColor;
    }


    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
