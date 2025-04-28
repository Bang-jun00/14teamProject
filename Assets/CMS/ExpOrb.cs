using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expAmount = 10; // 이 구슬이 주는 경험치 양  
    public float expmoveSpeed = 5f; // 구슬의 이동 속도
    public float magnetRange = 3f; // 구슬 빨려오기 시작하는 범위

    private Transform player; //플레이어의 위치

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어의 위치를 찾음  
    }

    public void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position); // 구슬과 플레이어의 거리 계산

        if (distance < magnetRange)
        {
            Vector2 direction = (player.position - transform.position).normalized; // 플레이어 방향으로 이동
            transform.position = Vector2.MoveTowards(transform.position, player.position, expmoveSpeed * Time.deltaTime); 
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어와 충돌했을 때  
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.GainExp(expAmount); // 플레이어에게 경험치 추가  
                Destroy(gameObject); // 구슬 삭제  
            }
        }
    }
}
