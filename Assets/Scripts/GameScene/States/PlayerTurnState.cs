using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public abstract class PlayerTurnState : BattleState
{
    internal static int currentPlayer;
    internal static int currentRound = 0;

    private CannonController playerCannonController;

    public PlayerTurnState(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    public override IEnumerator<float> OnStateEnter()
    {
        CannonController playerCannonController = CannonController.controllers[currentPlayer - 1];
        if (playerCannonController.cannonballCount <= 0)
        {
            battleSystem.SetState(new GameOverState(battleSystem));
            yield break;
        }
        PlayerController.ResetAllPlayerScoreMultipliers();
        if (currentRound == 1)
        {
            PlayerController playerController = PlayerController.controllers[currentPlayer - 1];
            playerController.SetPlayerScoreMultiplier(playerController.firstRoundScoreMultiplier);
        }
        Timing.RunCoroutine(SetTrajectoryPointsActive(currentPlayer, true));
    }

    public override void OnStateUpdate()
    {
        Timing.RunCoroutine(DisplayTrajectory());

        if (Input.GetButtonDown("Fire1"))
        {
            Timing.RunCoroutine(Shoot());
        }
    }

    public override IEnumerator<float> OnStateExit()
    {
        PlayerController playerController = PlayerController.controllers[currentPlayer - 1];
        yield return Timing.WaitForOneFrame;
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
