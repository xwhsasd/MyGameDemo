using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected Rigidbody2D rb;

    protected bool triggerCalled;
    protected string animBoolName;
    protected float stateTimer;

    public EnemyState(Enemy _enemyBase,EnemyStateMachine _statemachine,string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _statemachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);
        enemyBase.AssignLastAnimBoolName(animBoolName);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
