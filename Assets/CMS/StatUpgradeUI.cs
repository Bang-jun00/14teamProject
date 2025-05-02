using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUpgradeUI : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [Header("UI")]
    public Text skillPointText;
    public Button moveSpeedButton;
    public Button maxHealthButton;

    public void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        skillPointText.text = "Æ÷ÀÎÆ®" + playerStats.skillPoints;
        bool hasPoint = playerStats.skillPoints > 0;

        moveSpeedButton.interactable = hasPoint;
        maxHealthButton.interactable = hasPoint;
    }

    public void OnClickMoveSpeed()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.currentMoveSpeed += 0.5f;
            playerStats.skillPoints--;
            UpdateUI();
        }
    }

    public void OnClickMaxHealth()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.currentMaxHealth += 5f;
            playerStats.skillPoints--;
            UpdateUI();
        }
    }
}
