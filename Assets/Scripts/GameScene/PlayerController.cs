using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] internal int playerNum;
    
    private int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
    }
}
