using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private MonsterPool monsterPool;

    [Header("Spawner")]
    public GameObject monsterSpawn; //내가 스폰 시켜줄 프리팹
    public float timeToSpawn = 2f; //적이 생성되는 간격
    private float spawnTimer; //간격을 저장해줄 타이머
    
    private Transform target;

    [Header("SpawnPoint")]
    public Transform maxSpawn, minSpawn;

    void Start()
    {
        spawnTimer = timeToSpawn;

        GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
        target = player.transform;

        monsterPool = FindObjectOfType<MonsterPool>();
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0f)
        {
            spawnTimer = timeToSpawn;

            GameObject monster = monsterPool.GetMonster();
            monster.transform.position = SelectSpawnPoint();
            monster.transform.rotation = Quaternion.identity;
        }
        
        transform.position = target.position;  //스포너가 player를 따라다님
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;
        
        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f; // 0~1부터 랜덤한 소수 뽑아서 0.5보다 크면 true 작으면 false

        if(spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y); //y축 위아래 랜덤 지정

            if(Random.Range(0f,1f) > 0.5f)
            {
                spawnPoint.x = maxSpawn.position.x; //x 위치 값 오른쪽 고정
            }
            else
            {
                spawnPoint.x = minSpawn.position.x; //x 위치 값 왼쪽 고정
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x); //x축 왼쪽 오른쪽 랜덤 지정

            if(Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = maxSpawn.position.y; //y 위치 값 위에 고정
            }
            else
            {
                spawnPoint.y = minSpawn.position.y; //y 위치 값 아래 고정
            }
        }

        return spawnPoint;
    }
}    