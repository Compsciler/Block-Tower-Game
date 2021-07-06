using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class PlayerTurnState : BattleState
{
    public PlayerTurnState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    protected IEnumerator<float> DisplayTrajectory(int player)
    {
        CannonController.controllers[player - 1].DisplayTrajectory();
        yield return Timing.WaitForOneFrame;
    }

    protected IEnumerator<float> Shoot(int player)
    {
        CannonController.controllers[player - 1].Shoot();
        yield return Timing.WaitForOneFrame;
    }
}
