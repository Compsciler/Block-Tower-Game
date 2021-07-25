﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class AfterShotState : BattleState
{
    private float turnTimer = 0f;

    private float maxSpeedOfBlocksAndCannonballsThreshold = 0.1f;

    private float minTurnTime = 3f;
    private float maxTurnTime = 16f;

    private float minAddedTurnTimeAfterCannonballsDestroyed = 1f;
    private float minTurnTimeAfterCannonballsDestroyed;

    private float maxTurnTimeBeforeCannonballsDestroyed = 12f;

    private float fastForwardTimeScale = 3f;

    public AfterShotState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override void OnStateUpdate()
    {
        turnTimer += Time.deltaTime;
        float maxSpeedOfBlocksAndCannonballs = GetMaxSpeedOfBlocksAndCannonballs();
        // Debug.Log(maxSpeedOfBlocksAndCannonballs);
        if (turnTimer >= maxTurnTime)
        {
            GoToNextTurn();
            return;
        }
        if (turnTimer >= maxTurnTimeBeforeCannonballsDestroyed)
        {
            CannonballController.DestroyCannonballs();
            return;
        }

        if (maxSpeedOfBlocksAndCannonballs < maxSpeedOfBlocksAndCannonballsThreshold)
        {
            if (CannonballController.cannonBallGOs.Count == 0 && turnTimer >= minTurnTimeAfterCannonballsDestroyed)
            {
                GoToNextTurn();
            }
            else if (CannonballController.cannonBallGOs.Count != 0 && turnTimer >= minTurnTime)
            {
                CannonballController.DestroyCannonballs();
                minTurnTimeAfterCannonballsDestroyed = turnTimer + minAddedTurnTimeAfterCannonballsDestroyed;
            }
        }
    }

    public override IEnumerator<float> FastForwardTurn()
    {
        Time.timeScale = fastForwardTimeScale;
        battleSystem.fastForwardTurnButton.interactable = false;
        yield return Timing.WaitForOneFrame;
    }

    public void GoToNextTurn()
    {
        Time.timeScale = 1f;
        battleSystem.fastForwardTurnButton.interactable = true;

        PlayerTurnState.currentPlayer = PlayerTurnState.currentPlayer % GameManager.instance.playerCount + 1;
        switch (PlayerTurnState.currentPlayer)
        {
            case 1:
                battleSystem.SetState(new Player1TurnState(battleSystem));
                break;
            case 2:
                battleSystem.SetState(new Player2TurnState(battleSystem));
                break;
        }
    }

    public static float GetMaxSpeedOfBlocksAndCannonballs()
    {
        return Mathf.Max(BlockController.GetMaxSpeedOfBlocks(), CannonballController.GetMaxSpeedOfCannonballs());
    }
}
