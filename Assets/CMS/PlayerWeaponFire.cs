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
            Debug.LogError("�߻� ������ ���� ���� �ʾҽ��ϴ�.");
        }
    }
}
