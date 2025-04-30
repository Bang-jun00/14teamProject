using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoolManager : MonoBehaviour
{
    //프리펩들을 보관할 변수 2개가되면
    public GameObject[] weaponprefabs; //무기 프리펩들
    // 풀 담당을 하는 리스트들 도 2개가 되어야한다

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
        //선택한 풀에 있는 무기들 중에서 비어있는 무기를 가져온다
        //발견시 weapon 변수에 담는다.

        foreach(GameObject item in weaponpools[index])
        {
            if (!item.activeSelf)
            {//발견시 weapon 변수에 담는다.
                weapon = item;
                weapon.SetActive(true);
                break;
            }
        }

        //못찾았으면?
        //새롭게 생성하고 weapon 변수에 담는다.
        if(weapon == null)
        {
            weapon = Instantiate(weaponprefabs[index], transform); //트랜스폼을  //부모로 설정해준다. 풀 매니저에 하위객체로 생성하기때문에 미관상보기좋음 
            weaponpools[index].Add(weapon);
        }


        return weapon;
    }
}
