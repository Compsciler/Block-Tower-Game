using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class PlayerTurnState : BattleState
{
    internal static int currentPlayer;

    public PlayerTurnState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator<float> OnStateEnter()
    {
        Timing.RunCoroutine(SetTrajectoryPointsActive(currentPlayer, true));
        yield return Timing.WaitForOneFrame;
    }

    public override void OnStateUpdate()
    {
        Timing.RunCoroutine(DisplayTrajectory());

        if (Input.GetButtonDown("Fire1"))
        {
            Timing.RunCoroutine(Shoot());
        }
    }

    protected IEnumerator<float> DisplayTrajectory(int player)
    {
        CannonController.controllers[player - 1].DisplayTrajectory();
        yield return Timing.WaitForOneFrame;
    }

    protected IEnumerator<float> Shoot(int player)
    {
        CannonController.controllers[player - 1].Shoot();
        Timing.RunCoroutine(SetTrajectoryPointsActive(player, false));
        battleSystem.SetState(new AfterShotState(battleSystem));
        yield return Timing.WaitForOneFrame;
    }

    private IEnumerator<float> SetTrajectoryPointsActive(int player, bool isActive)
    {
        CannonController.controllers[player - 1].SetTrajectoryPointsActive(isActive);
        yield return Timing.WaitForOneFrame;
    }
}
