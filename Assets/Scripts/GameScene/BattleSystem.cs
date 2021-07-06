using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class BattleSystem : StateMachine<BattleState>
{
    void Start()
    {
        SetState(new StartState(this));
    }

    void Update()
    {
        Timing.RunCoroutine(state.DisplayTrajectory());

        if (Input.GetButtonDown("Fire1"))
        {
            Timing.RunCoroutine(state.Shoot());
        }
    }
}
