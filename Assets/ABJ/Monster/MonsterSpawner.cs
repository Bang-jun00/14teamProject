using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private MonsterPool monsterPool;

    [Header("Spawner")]
    public GameObject monsterSpawn; //���� ���� ������ ������
    public float timeToSpawn = 2f; //���� �����Ǵ� ����
    private float spawnTimer; //������ �������� Ÿ�̸�
    
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
        
        transform.position = target.position;  //�����ʰ� player�� ����ٴ�
    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;
        
        bool spawnVerticalEdge = Random.Range(0f, 1f) > 0.5f; // 0~1���� ������ �Ҽ� �̾Ƽ� 0.5���� ũ�� true ������ false

        if(spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y); //y�� ���Ʒ� ���� ����

            if(Random.Range(0f,1f) > 0.5f)
            {
                spawnPoint.x = maxSpawn.position.x; //x ��ġ �� ������ ����
            }
            else
            {
                spawnPoint.x = minSpawn.position.x; //x ��ġ �� ���� ����
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x); //x�� ���� ������ ���� ����

            if(Random.Range(0f, 1f) > 0.5f)
            {
                spawnPoint.y = maxSpawn.position.y; //y ��ġ �� ���� ����
            }
            else
            {
                spawnPoint.y = minSpawn.position.y; //y ��ġ �� �Ʒ� ����
            }
        }

        return spawnPoint;
    }
}    