using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private PlayerStats playerStats;

    private bool initialized = false;

    private void Start()
    {
        healthSlider.maxValue = playerStats.currentMaxHealth;
        healthSlider.value = playerStats.currentHealth;
    }

    private void Update()
    {
        if (!initialized)
        {
            if (playerStats.currentMaxHealth > 0)
            {
                healthSlider.maxValue = playerStats.currentMaxHealth;
                initialized = true;
            }
        }
        healthSlider.value = playerStats.currentHealth;
    }
}
