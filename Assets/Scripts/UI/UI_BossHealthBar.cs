using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BossHealthBar : MonoBehaviour
{
    [SerializeField] private UI_HealthBar healthBar;
    private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        slider.maxValue = healthBar.myStats.GetMaxHealthValue();
        slider.value = healthBar.myStats.currentHealth;
    }
    private void Update()
    {
        UpdateHealthUI();
    }

}
