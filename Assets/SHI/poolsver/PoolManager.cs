using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{       //프리펩들을 보관할 변수 2개가되면
    public GameObject[] prefabs;  //풀을 사용할 프리펩들

    // 풀 담당을 하는 리스트들 도 2개가 되어야한다
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject chioce = null;
        // 고른 풀에 놓고(비활성화된) 있는 게임오브젝트 접근

        //발견시 선택한 변수에 할당
        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                chioce = item;
                chioce.SetActive(true);
                break;
                //발견시 선택한 변수에 할당
            }
        }

        //못 찾았으면??
        
        if (!chioce )
        {
            chioce = Instantiate(prefabs[index], transform);
            pools[index].Add(chioce);
            //새롭게 생성하고 선택한 변수에 할당
        }

        return chioce;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
