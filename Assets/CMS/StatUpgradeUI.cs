using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatUpgradeUI : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [Header("UI")]
    public TMP_Text skillPointText;
    public Button moveSpeedButton;
    public Button maxHealthButton;


    public void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (skillPointText == null)
        {
            Debug.LogError("skillPointText가 연결되지 않았습니다.");
            return;
        }

        if (playerStats == null)
        {
            Debug.LogError("playerStats가 연결되지 않았습니다.");
            return;
        }
        skillPointText.text = "SP : " + playerStats.skillPoints;
        bool hasPoint = playerStats.skillPoints > 0;

        moveSpeedButton.interactable = hasPoint;
        maxHealthButton.interactable = hasPoint;
    }

    public void OnClickMoveSpeed()
    {
        Debug.Log("이동속도 증가 버튼 눌림!");
        if (playerStats.skillPoints > 0)
        {
            playerStats.IncreaseMoveSpeed(0.5f);
            Debug.Log("속도 +0.5 !"); 
            playerStats.skillPoints--;
            UpdateUI();
        }
    }

    public void OnClickMaxHealth()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.IncreaseMaxHealth(5f);
            Debug.Log("체력 +5 !");
            playerStats.skillPoints--;
            UpdateUI();
        }
    }
}
