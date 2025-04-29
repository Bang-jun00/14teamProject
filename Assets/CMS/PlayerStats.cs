using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private float baseMaxHealth = 100f;
    [SerializeField] private float baseMoveSpeed = 5f;

    [Header("���� �� ����ġ")]
    [SerializeField] private int Playerlevel = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int maxExp = 100;

    [Header("���� ����")]
    [SerializeField] private float invincibleDuration; // ���� ���ӽð� 
    private bool isInvincible = false;

    public float currentMaxHealth;
    public float currentHealth;
    public float currentMoveSpeed;

    private void Start()
    {
        currentMaxHealth = baseMaxHealth;
        currentHealth = currentMaxHealth;
        currentMoveSpeed = baseMoveSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GainExp(10);
        }
    }
    public void TakeDamage(float damage)
    {
        if (isInvincible)
        {
            Debug.Log("���� ����! �������� ���� ����");
            return;
        }

        currentHealth -= damage;

        Debug.Log($"�÷��̾� ü��: {currentHealth}/{currentMaxHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(InvincibilityCoroutine());
    }

    //�ִ� ü�� ����, �ִ� ü���� �����ϸ� ���� ü�µ� ���� ����
    public void IncreaseMaxHealth(float amount)
    {
        currentMaxHealth += amount;
        currentHealth = currentMaxHealth;
    }

    //�̵��ӵ� ����
    public void IncreaseMoveSpeed(float amount)
    {
        currentMoveSpeed += amount;
    }

    public float CurrentMoveSpeed
    {
        get { return currentMoveSpeed; }
    }

    private void Die()
    {
        Debug.Log("�÷��̾� ���");
    }

    public void GainExp(int amount)
    {
        if (Playerlevel >= 70) return;

        currentExp += amount;
        while (currentExp >= maxExp)
        {
            if (Playerlevel >= 70)
            {
                currentExp = 0;
                return;
            }
            currentExp -= maxExp;
            LevelUp();
        }
    }



    private void LevelUp()
    {
        Playerlevel++;
        maxExp = Mathf.FloorToInt(maxExp * 1.2f);
        Debug.Log("������! ���� ����: " + Playerlevel);
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleDuration);
        isInvincible = false;
    }


}

