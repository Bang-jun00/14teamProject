using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("스탯")]
    [SerializeField] private float baseMaxHealth = 100f;
    [SerializeField] private float baseMoveSpeed = 5f;

    [Header("레벨 및 경험치")]
    [SerializeField] private int Playerlevel = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int maxExp = 100;

    [Header("무적 설정")]
    [SerializeField] private float invincibleDuration; // 무적 지속시간 
    public bool isInvincible = false;

    public float currentMaxHealth;
    public float currentHealth;
    public float currentMoveSpeed;

    [Header("스킬(스탯)포인트")]
    public int skillPoints = 0; // 스킬 포인트

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
            Debug.Log("무적 상태! 데미지를 받지 않음");
            return;
        }

        currentHealth -= damage;

        Debug.Log($"플레이어 체력: {currentHealth}/{currentMaxHealth}");
        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(InvincibilityCoroutine());
    }

    //최대 체력 증가, 최대 체력이 증가하면 현재 체력도 같이 증가
    public void IncreaseMaxHealth(float amount)
    {
        currentMaxHealth += amount;
        currentHealth = currentMaxHealth;
    }

    //이동속도 증가
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
        Debug.Log("플레이어 사망");
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
                Debug.Log("StatUpgradeUI를 찾을 수 없습니다.");
        
        Debug.Log("레벨업! 현재 레벨: " + Playerlevel);

       
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

