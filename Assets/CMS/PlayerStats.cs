using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private float baseMaxHealth = 100f;
    [SerializeField] private float baseMoveSpeed = 100f;

    [Header("���� �� ����ġ")]
    [SerializeField] private int level = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int maxExp = 100;

    private float currentMaxHealth;
    private float correntHealth;
    private float currentMoveSpeed;

    private void Start()
    {
        currentMaxHealth = baseMaxHealth;
        correntHealth = currentMaxHealth;
        currentMoveSpeed = baseMoveSpeed;
    }

    public void TakeDamage(float damage)
    {
        correntHealth -= damage;
        if (correntHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseMaxHealth(float amount)
    {
        currentMaxHealth += amount;
        correntHealth = currentMaxHealth;
    }
    
    public void IncreaseMoveSpeed(float amount)
    {
        currentMoveSpeed += amount;
    }

    public float CurrentmoveSpeed
    {
        get { return currentMoveSpeed; }
    }

    private void Die()
    { 
        Debug.Log("�÷��̾� ���");
    }

    public void GainExp(int amount)
    {
        if(CompressionLevel >=)
    }


}

