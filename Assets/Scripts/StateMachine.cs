using UnityEngine;
using MEC;

public abstract class StateMachine<StateType> : MonoBehaviour where StateType : State
{
    protected StateType state;

    public void SetState(StateType state)
    {
        Timing.RunCoroutine(state.OnStateExit());
        this.state = state;
        Timing.RunCoroutine(state.OnStateEnter());
    }

    void Update()  // LateUpdate() ?
    {
        state.OnStateUpdate();
    }
}