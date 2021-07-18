using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class GameOverState : BattleState
{
    public GameOverState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator<float> OnStateEnter()
    {
        Debug.Log("Game over!");
        yield return Timing.WaitForOneFrame;
    }
}
