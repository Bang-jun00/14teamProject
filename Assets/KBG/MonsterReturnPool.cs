using UnityEngine;

public class MonsterReturnPool : MonoBehaviour
{
    
    public MonsterPool monsterPool;
    public MonsterSpawner monsterSpawner;
    public GameManager gameManager;

    public void ReturnAllMonsters()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");

        foreach (GameObject monster in monsters)
        {
            if (monster.activeInHierarchy)
            {
                monsterPool.ReturnMonster(monster);
            }
        }
    }


    void Update()
    {
        if (gameManager.IsGameCleared || gameManager.IsGameOvered)
            ReturnAllMonsters();
    }
}
