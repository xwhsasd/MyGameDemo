using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStunState : EnemyState
{
    private Enemy_Slime enemy;

    public SlimeStunState(Enemy _enemyBase, EnemyStateMachine _statemachine, string _animBoolName,Enemy_Slime _enemy) : base(_enemyBase, _statemachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.fx.InvokeRepeating("RedColorBlink", 0, .1f);
        stateTimer = enemy.stunDuration;

        rb.velocity = new Vector2(-enemy.facingDir * enemy.stunDirection.x, enemy.stunDirection.y);

    }

    public override void Exit()
    {
        base.Exit();

        enemy.stats.MakeInvincibale(false);
    }

    public override void Update()
    {
        base.Update();
        if (rb.velocity.y < .1f && enemy.IsGroundDetected())
        {
            enemy.fx.Invoke("CancelColorBlink", 0);
            enemy.anim.SetTrigger("StunFold");
            enemy.stats.MakeInvincibale(true);
        }

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
