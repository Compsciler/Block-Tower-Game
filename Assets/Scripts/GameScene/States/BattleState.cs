using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class BattleState : State
{
    protected BattleSystem battleSystem;

    public BattleState(BattleSystem battleSystem)
    {
        this.battleSystem = battleSystem;
    }

    public virtual IEnumerator<float> DisplayTrajectory()
    {
        yield return Timing.WaitForOneFrame;
    }

    public virtual IEnumerator<float> Shoot()
    {
        yield return Timing.WaitForOneFrame;
    }

    public virtual IEnumerator<float> FastForwardTurn()
    {
        yield return Timing.WaitForOneFrame;
    }
}
