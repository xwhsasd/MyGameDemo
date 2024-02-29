using UnityEngine;

public class PlayerCatchState : PlayerState
{

    private Vector3 catchLight;
    public PlayerCatchState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        catchLight = player.catchLight.position;
        catchLight = new Vector3(catchLight.x - player.facingDir * .5f, catchLight.y - 2.2f);//set player to fit position

    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (player.facingDir != xInput && xInput != 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }

        if (Input.GetKeyDown(KeyCode.A) && player.facingDir == -1) 
        {
            player.Flip();
            catchLight = new Vector3(catchLight.x - player.facingDir * 1f, catchLight.y);
        }

        if (Input.GetKeyDown(KeyCode.D) && player.facingDir == 1)
        {
            player.Flip();
            catchLight = new Vector3(catchLight.x - player.facingDir * 1f, catchLight.y);
        }

        player.transform.position = catchLight;
        player.SetZeroVelocity();
    }
}
