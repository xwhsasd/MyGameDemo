using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGoundState : EnemyState
{
    protected Transform player;
    protected Enemy_Slime enemy;
    public SlimeGoundState(Enemy _enemyBase, EnemyStateMachine _statemachine, string _animBoolName, Enemy_Slime _enemy) : base(_enemyBase, _statemachine, _animBoolName)
    {
       
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;
    }
    public override void Update()
    {
        base.Update();
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < enemy.agroDistance)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }

    public override void Exit()
    {
        base.Exit();

    }
}
