using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{       //��������� ������ ���� 2�����Ǹ�
    public GameObject[] prefabs;  //Ǯ�� ����� �������

    // Ǯ ����� �ϴ� ����Ʈ�� �� 2���� �Ǿ���Ѵ�
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
        // �� Ǯ�� ����(��Ȱ��ȭ��) �ִ� ���ӿ�����Ʈ ����

        //�߽߰� ������ ������ �Ҵ�
        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                chioce = item;
                chioce.SetActive(true);
                break;
                //�߽߰� ������ ������ �Ҵ�
            }
        }

        //�� ã������??
        
        if (!chioce )
        {
            chioce = Instantiate(prefabs[index], transform);
            pools[index].Add(chioce);
            //���Ӱ� �����ϰ� ������ ������ �Ҵ�
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
