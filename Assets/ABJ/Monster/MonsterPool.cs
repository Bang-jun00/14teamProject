using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int poolSize = 500; //뱀서류 몬스터 겁나 많이 나와서 풀 사이즈 넉넉하게 잡기.
    private Stack<GameObject> monsterPool = new Stack<GameObject>();

    private void Start()
    {
       for(int i = 0;  i < poolSize; i++)
       {
            GameObject monster = Instantiate(monsterPrefab);
            monster.SetActive(false);
            monsterPool.Push(monster);
       }
    }

    public GameObject GetMonster()
    {
        if(monsterPool.Count > 0)
        {
            GameObject monster = monsterPool.Pop();
            monster.SetActive(true);
            
            MonsterController monsterController = monster.GetComponent<MonsterController>();
            if(monsterController != null)
            {
                monsterController.ResetMonsterHealth();
            }
                        
            return monster;
        }
        else
        {
            GameObject monster = Instantiate(monsterPrefab); //풀에 남아있지 않으면 새로 만들어서 줌(안전 처리)
            return monster;
        }
    }

    public void ReturnMonster(GameObject monster)
    {               
        monster.SetActive(false);
        monsterPool.Push(monster);
    }


}
