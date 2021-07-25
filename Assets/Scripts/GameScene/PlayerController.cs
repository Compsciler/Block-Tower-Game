using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] internal int playerNum;
    
    private int score = 0;

    [SerializeField] internal float firstRoundScoreMultiplier = 1f;
    private float playerScoreMultiplier = 1f;
    
    [SerializeField] TMP_Text scoreText;

    internal static PlayerController[] controllers;

    void Awake()
    {
        InitializeControllerLists();
    }

    void Update()
    {
        
    }

    public void AddScore(int addedScore)
    {
        score += Mathf.RoundToInt(addedScore * playerScoreMultiplier);
        SetScoreText();
    }

    public void SetScoreText()
    {
        if (playerScoreMultiplier == 1f)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            scoreText.text = $"({playerScoreMultiplier}×) Score: " + score;
        }
    }

    public void SetPlayerScoreMultiplier(float playerScoreMultiplier)
    {
        this.playerScoreMultiplier = playerScoreMultiplier;
        SetScoreText();
    }
    public static void ResetAllPlayerScoreMultipliers()
    {
        foreach (PlayerController controller in controllers)
        {
            controller.SetPlayerScoreMultiplier(1f);
            controller.SetScoreText();
        }
    }

    public void InitializeControllerLists()
    {
        if (controllers == null)
        {
            controllers = new PlayerController[GameManager.instance.playerCount];
        }
        controllers[playerNum - 1] = this;
    }

    public static List<int> GetWinningPlayers()
    {
        List<int> winningPlayers = new List<int>();
        int maxScore = int.MinValue;
        foreach (PlayerController controller in controllers)
        {
            if (controller.score > maxScore)
            {
                maxScore = controller.score;
                winningPlayers = new List<int>{controller.playerNum};
            }
            else if (controller.score == maxScore)
            {
                winningPlayers.Add(controller.playerNum);
            }
        }
        return winningPlayers;
    }
}
