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

    private float currentMaxHealth;
    private float currentHealth;
    private float currentMoveSpeed;

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
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
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
        Debug.Log("레벨업! 현재 레벨: " + Playerlevel);
    }


}

