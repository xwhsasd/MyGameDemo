using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBringerTrigger : EnemyAnimationTriggers
{
    private Enemy_DeathBringer enemyDeathBringer => GetComponentInParent<Enemy_DeathBringer>();

    private void Relocate() => enemyDeathBringer.FindPosition();
    private void MakeInvisiable() => enemyDeathBringer.fx.MakeTransprent(true);
    private void MakeVisiable() => enemyDeathBringer.fx.MakeTransprent(false);

}
