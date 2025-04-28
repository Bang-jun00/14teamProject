using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expAmount = 10; // �� ������ �ִ� ����ġ ��  
    public float expmoveSpeed = 5f; // ������ �̵� �ӵ�
    public float magnetRange = 3f; // ���� �������� �����ϴ� ����

    private Transform player; //�÷��̾��� ��ġ

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾��� ��ġ�� ã��  
    }

    public void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position); // ������ �÷��̾��� �Ÿ� ���

        if (distance < magnetRange)
        {
            Vector2 direction = (player.position - transform.position).normalized; // �÷��̾� �������� �̵�
            transform.position = Vector2.MoveTowards(transform.position, player.position, expmoveSpeed * Time.deltaTime); 
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾�� �浹���� ��  
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.GainExp(expAmount); // �÷��̾�� ����ġ �߰�  
                Destroy(gameObject); // ���� ����  
            }
        }
    }
}
