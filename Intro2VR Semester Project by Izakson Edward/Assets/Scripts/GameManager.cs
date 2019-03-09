using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [System.NonSerialized] public Transform _cameraTransform;
    public PlayerController player;

    public string playerName { get; private set; }

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);

        }

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame()
    {
        _cameraTransform = Camera.main.transform;
        player = FindObjectOfType<PlayerController>();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitGame();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

}
