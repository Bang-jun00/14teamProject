using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponFire : MonoBehaviour
{
    public Transform weaponFirePoint;

    private void Awake()
    {
        if(weaponFirePoint == null)
        {
            Debug.LogError("발사 지점이 설정 되지 않았습니다.");
        }
    }
}
