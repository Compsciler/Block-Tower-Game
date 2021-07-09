using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

// For button click methods and battle Start() and Update()
public class BattleSystem : StateMachine<BattleState>
{
    void Start()
    {
        SetState(new StartState(this));
    }

    protected override void Update()
    {
        base.Update();
    }
}
