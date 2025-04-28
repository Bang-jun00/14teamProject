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


}

