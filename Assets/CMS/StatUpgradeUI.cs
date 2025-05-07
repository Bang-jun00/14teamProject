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
            Debug.LogError("skillPointText�� ������� �ʾҽ��ϴ�.");
            return;
        }

        if (playerStats == null)
        {
            Debug.LogError("playerStats�� ������� �ʾҽ��ϴ�.");
            return;
        }
        skillPointText.text = "SP : " + playerStats.skillPoints;
        bool hasPoint = playerStats.skillPoints > 0;

        moveSpeedButton.interactable = hasPoint;
        maxHealthButton.interactable = hasPoint;
    }

    public void OnClickMoveSpeed()
    {
        Debug.Log("�̵��ӵ� ���� ��ư ����!");
        if (playerStats.skillPoints > 0)
        {
            playerStats.IncreaseMoveSpeed(0.5f);
            Debug.Log("�ӵ� +0.5 !"); 
            playerStats.skillPoints--;
            UpdateUI();
        }
    }

    public void OnClickMaxHealth()
    {
        if (playerStats.skillPoints > 0)
        {
            playerStats.IncreaseMaxHealth(5f);
            Debug.Log("ü�� +5 !");
            playerStats.skillPoints--;
            UpdateUI();
        }
    }
}
