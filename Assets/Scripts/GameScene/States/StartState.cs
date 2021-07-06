using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class StartState : BattleState
{
    public StartState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator<float> OnStateEnter()
    {
        battleSystem.SetState(new Player1TurnState(battleSystem));
        yield return Timing.WaitForOneFrame;
    }
}
