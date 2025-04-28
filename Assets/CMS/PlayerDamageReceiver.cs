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
            Monster monster = collision.GetComponent<Monster>();
            if (monster != null)
            {
                playerStats.TakeDamage(monster.Damage); // �÷��̾�� ���ظ� ��  
            }
        }  
    }
}


