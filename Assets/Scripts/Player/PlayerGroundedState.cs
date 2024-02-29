using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.R) && player.skill.blackhole.blackholeUnlocked)
        {
            if (player.skill.blackhole.cooldownTimer > 0)
            {
                player.fx.CreatePopUpText("ººƒ‹¿‰»¥");
                return;
            }

            stateMachine.ChangeState(player.blackhole);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && HasNoSwordExist() && player.skill.sword.swordUnlocked)
        {
            stateMachine.ChangeState(player.aimSowrdState);
        }

        if (Input.GetKeyDown(KeyCode.Q) && player.skill.parry.parryUnlocked)
        {
            stateMachine.ChangeState(player.counterAttack);
        }

        if(Input.GetMouseButtonDown(0))
        {
            stateMachine.ChangeState(player.primaryAttack);
        }

        if (!player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.airState);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W))) && player.IsGroundDetected()) 
        {
            stateMachine.ChangeState(player.jumpState);
        }
    }

    private bool HasNoSwordExist()
    {
        if (!player.sword)
        {
            return true;
        }
        else
        {
            player.sword.GetComponent<Sword_Skill_Controller>().ReturnSword();
            return false;
        }
    }
}
