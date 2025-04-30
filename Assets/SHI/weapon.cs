using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public int id; //해당 무기의 아이디
    public int prefabid; //해당 무기의 프리팹
    public float damage = 10f; //데미지
    public int weaponlevel;
    public float attackSpeed = 1f; //공격속도

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                attackSpeed = -150;
                rollattack();
                break;
            default:
                break;
        }
    }

    void rollattack()
    {
        //회전 공격
        //회전 공격을 위한 코드 작성
        for(int i =0; i < weaponlevel; i++)
        {
            Transform spinball = WeaponManager.instance.weaponPool.Get(prefabid).transform; //무기 풀에서 무기 가져오기
            spinball.parent = transform; //부모 설정
            spinball.GetComponent<spinfireball>().Init(damage, -1); //  -1 무기 샤프니스는 무한함.
            //회전 공격을 위한 코드 작성
        }
    }
}
