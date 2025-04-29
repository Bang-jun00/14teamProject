using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int poolSize = 500; //�켭�� ���� �̳� ���� ���ͼ� Ǯ ������ �˳��ϰ� ���.
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
            GameObject monster = Instantiate(monsterPrefab); //Ǯ�� �������� ������ ���� ���� ��(���� ó��)
            return monster;
        }
    }

    public void ReturnMonster(GameObject monster)
    {               
        monster.SetActive(false);
        monsterPool.Push(monster);
    }


}
