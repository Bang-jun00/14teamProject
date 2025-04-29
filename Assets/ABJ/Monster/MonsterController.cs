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


    void Start()
    {
        monsterCurrentHealth = monsterMaxHealth; // 스타트시 체력 초기화

        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        rb.velocity = (target.position - transform.position).normalized * monsterSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            Axe axe = collision.GetComponent<Axe>();

            if(axe != null)
            {
                float damage = axe.AxeDamage;
                TakeDamage(damage);
            }
        }
    }
    public void TakeDamage(float Damage)
    {
        monsterCurrentHealth -= Damage;
        Debug.Log($"몬스터 피격받음 현재 체력 : {monsterCurrentHealth}");

        if(monsterCurrentHealth <= 0 )
        {
            Die();
        }
    }

    public void ResetMonsterHealth()
    {
        monsterCurrentHealth = monsterMaxHealth;
    }

    private void Die()
    {
        Debug.Log("몬스터 사망");
        monsterPool.ReturnMonster(gameObject);
    }
   
    
}
