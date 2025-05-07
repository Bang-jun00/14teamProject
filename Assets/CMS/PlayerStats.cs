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
    public bool isInvincible = false;

    public float currentMaxHealth;
    public float currentHealth;
    public float currentMoveSpeed;

    [Header("��ų(����)����Ʈ")]
    public int skillPoints = 0; // ��ų ����Ʈ

    public SpriteRenderer spriteRenderer;
    public Scan scan;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scan = GetComponent<Scan>();
    }

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
        skillPoints++;

        StatUpgradeUI ui = FindObjectOfType<StatUpgradeUI>();
        if(ui != null)
            ui.UpdateUI();
            else
                Debug.Log("StatUpgradeUI�� ã�� �� �����ϴ�.");
        
        Debug.Log("������! ���� ����: " + Playerlevel);

       
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        float blinkInterval = 0.1f;
        float invincibleTime = 0f;
        while (invincibleTime < invincibleDuration)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);

            invincibleTime += blinkInterval * 2;
        }
        isInvincible = false;
        spriteRenderer.enabled = true;
    }


}

