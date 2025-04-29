using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats; // �÷��̾� ���� ��ũ��Ʈ

    private void Start()
    {
        if (playerStats == null)
            playerStats = GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �浹���� ��
        if (collision.CompareTag("Monster"))
        {
            MonsterController monster = collision.GetComponent<MonsterController>();
            if (monster != null)
            {
                playerStats.TakeDamage(monster.monsterDamage); // �÷��̾�� ���ظ� ��  
            }
        }
    }
}


