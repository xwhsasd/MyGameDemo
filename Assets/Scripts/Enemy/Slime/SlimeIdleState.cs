using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : SlimeGoundState
{
    public SlimeIdleState(Enemy _enemyBase, EnemyStateMachine _statemachine, string _animBoolName,Enemy_Slime _enemy) : base(_enemyBase, _statemachine, _animBoolName, _enemy)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();

        //AudioManager.instance.PlaySFX(24, enemy.transform);
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
