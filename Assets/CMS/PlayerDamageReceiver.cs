using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats; // 플레이어 스탯 스크립트

    private void Start()
    {
        if (playerStats == null)
            playerStats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적과 충돌했을 때
        if (collision.CompareTag("Monster"))
        {
            MonsterController monster = collision.GetComponent<MonsterController>();
            if (monster != null)
            {
                playerStats.TakeDamage(monster.monsterDamage); // 플레이어에게 피해를 줌  
            }
        }
    }
}


