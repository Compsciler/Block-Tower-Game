using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class Player2TurnState : PlayerTurnState
{
    public Player2TurnState(BattleSystem battleSystem) : base(battleSystem)
    {
        currentPlayer = 2;
    }

    public override IEnumerator<float> DisplayTrajectory()
    {
        Timing.RunCoroutine(DisplayTrajectory(2));
        yield return Timing.WaitForOneFrame;
    }

    public override IEnumerator<float> Shoot()
    {
        Timing.RunCoroutine(Shoot(2));
        yield return Timing.WaitForOneFrame;
    }
}
