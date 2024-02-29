using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossFight_FX : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] private ParallaxBackground background1;
    [SerializeField] private ParallaxBackground background2;

    [Header("Particles")]
    [SerializeField] private GameObject Particles;

    [SerializeField] private Enemy_DeathBringer boss;
    [SerializeField] private UI_BossHealthBar bossHealthBar;

    private bool playerArriveGate = false;
    private bool hasCloseBG_FX = false;

    void Update()
    {
        if (boss == null)
            return;

        BossFightHealthBar();
        BossFightBG_FX();
        BossFightPatycles_FX();
    }

    private void BossFightHealthBar()
    {
        if(boss.bossFightBegun)
            bossHealthBar.gameObject.SetActive(true);
        if(boss.bossDead)
            bossHealthBar.gameObject.SetActive(false);
    }

    private void BossFightPatycles_FX()
    {
        if (playerArriveGate && !boss.bossDead)
            Particles.SetActive(true);
        if (boss.bossDead)
            Particles.SetActive(false);
    }

    private void BossFightBG_FX()
    {
        if (playerArriveGate && !boss.bossDead && hasCloseBG_FX)
        {
            hasCloseBG_FX = false;
            background1.gameObject.SetActive(true);
            background2.gameObject.SetActive(true);
            background1.OpenBGParallax();
            background2.OpenBGParallax();
        }
        else if ((boss.bossDead || playerArriveGate == false) && !hasCloseBG_FX) 
        {
            hasCloseBG_FX = true;
            background1.gameObject.SetActive(false);
            background2.gameObject.SetActive(false);
            background1.CloseBGParallax();
            background2.CloseBGParallax();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            playerArriveGate = true;
            boss.playerArriveGate = playerArriveGate;
        }
    }
}
