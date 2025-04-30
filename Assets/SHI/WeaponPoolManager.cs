using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoolManager : MonoBehaviour
{
    //��������� ������ ���� 2�����Ǹ�
    public GameObject[] weaponprefabs; //���� �������
    // Ǯ ����� �ϴ� ����Ʈ�� �� 2���� �Ǿ���Ѵ�

    List<GameObject>[] weaponpools;


    private void Awake()
    {
        weaponpools = new List<GameObject>[weaponprefabs.Length];

        for(int i = 0; i < weaponpools.Length; i++)
        {
            weaponpools[i] = new List<GameObject>();
        }

        Debug.Log(weaponpools.Length);

    }

    public GameObject Get(int index)
    {
        GameObject weapon = null;
        //������ Ǯ�� �ִ� ����� �߿��� ����ִ� ���⸦ �����´�
        //�߽߰� weapon ������ ��´�.

        foreach(GameObject item in weaponpools[index])
        {
            if (!item.activeSelf)
            {//�߽߰� weapon ������ ��´�.
                weapon = item;
                weapon.SetActive(true);
                break;
            }
        }

        //��ã������?
        //���Ӱ� �����ϰ� weapon ������ ��´�.
        if(weapon == null)
        {
            weapon = Instantiate(weaponprefabs[index], transform); //Ʈ��������  //�θ�� �������ش�. Ǯ �Ŵ����� ������ü�� �����ϱ⶧���� �̰��󺸱����� 
            weaponpools[index].Add(weapon);
        }


        return weapon;
    }
}
