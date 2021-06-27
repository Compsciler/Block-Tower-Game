using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] internal int playerNum;
    
    private int score = 0;

    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score;
    }
}
