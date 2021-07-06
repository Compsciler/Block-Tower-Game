using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class Player1TurnState : PlayerTurnState
{
    public Player1TurnState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator<float> DisplayTrajectory()
    {
        Timing.RunCoroutine(DisplayTrajectory(1));
        yield return Timing.WaitForOneFrame;
    }

    public override IEnumerator<float> Shoot()
    {
        Timing.RunCoroutine(Shoot(1));
        yield return Timing.WaitForOneFrame;
    }
}
