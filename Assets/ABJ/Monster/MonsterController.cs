using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    MonsterPool monsterPool; //참조

    private Transform target;
    Rigidbody2D rb;

    [Header("MonsterStat")]
    public float monsterMaxHealth = 100f;
    public float monsterCurrentHealth;
    public float monsterSpeed;
    public float monsterDamage;

    [Header("KnockBack")]
    public float monsterKnockBackTime = 0.5f;
    private float monsterKnockBackDelay;
    bool monsterKnockBack;

    [Header("DropPickUp")]
    public GameObject expOrbPrefab;

    void Start()
    {
        monsterCurrentHealth = monsterMaxHealth; // 스타트시 체력 초기화

        target = FindObjectOfType<PlayerMovement>().transform;
        monsterPool = FindObjectOfType<MonsterPool>();
    }

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (target.position - transform.position).normalized * monsterSpeed;
        
        if(monsterKnockBackDelay > 0 )
        {
            monsterKnockBackDelay -= Time.deltaTime;

            if(monsterSpeed > 0) //스피드가 0보다 작으면
            {
                monsterSpeed = -monsterSpeed * 2f; //이동속도의 1.5배만큼 감소(뒤로 이동)
            }

            if(monsterKnockBackDelay <= 0) //0보다 딜레이가 작거나 같으면
            {
                monsterSpeed = Mathf.Abs(monsterSpeed * 0.5f); //절댓값으로 이동속도를 0.5만큼 곱하여 서서히 복구되게끔
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            Axe axe = collision.GetComponent<Axe>();

            if(axe != null)
            {
                float damage = axe.AxeDamage;
                TakeDamage(damage, true);
            }
        }
    }
    public void TakeDamage(float damage)
    {
        monsterCurrentHealth -= damage;
        Debug.Log($"몬스터 피격받음 현재 체력 : {monsterCurrentHealth}");

        if(monsterCurrentHealth <= 0 )
        {
            Die();
        }
    }

    public void TakeDamage(float damage, bool monsterKnockBack)
    {
        TakeDamage(damage);

        if(monsterKnockBack == true)
        {
            monsterKnockBackDelay = monsterKnockBackTime;
        }
    }

    public void ResetMonsterHealth()
    {
        monsterCurrentHealth = monsterMaxHealth;
    }

    private void Die()
    {
        Debug.Log("몬스터 사망");
        
        if(expOrbPrefab != null )
        {
            Instantiate(expOrbPrefab, transform.position, Quaternion.identity);
        }
        
        monsterPool.ReturnMonster(gameObject);
    }
   
    
}
