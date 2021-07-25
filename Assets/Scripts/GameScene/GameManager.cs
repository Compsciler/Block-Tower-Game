using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    internal static GameManager instance;

    internal int playerCount = 2;

    void Awake()  // Script Execution Order = -10
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;  // Adding OnSceneUnloaded() to delegate call when scene unloaded
    }

    void Update()
    {
        
    }

    public void ResetStaticVariables()
    {
        PlayerTurnState.currentRound = 0;
        PlayerController.controllers = null;
        CannonController.controllers = null;
        Debug.Log("Static variables reset!");
    }

    public void OnSceneUnloaded(Scene currentScene)
    {
        ResetStaticVariables();
        SceneManager.sceneUnloaded -= OnSceneUnloaded;  // Resets delegate
    }
}
