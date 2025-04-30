using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance; //싱글톤으로 사용하기위한 변수

    public WeaponPoolManager weaponPool; //무기 풀 매니저

    private void Awake()
    {
        instance = this; //싱글톤으로 사용하기위한 초기화
    }


}
