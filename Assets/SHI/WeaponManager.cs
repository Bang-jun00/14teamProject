using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance; //�̱������� ����ϱ����� ����

    public WeaponPoolManager weaponPool; //���� Ǯ �Ŵ���

    private void Awake()
    {
        instance = this; //�̱������� ����ϱ����� �ʱ�ȭ
    }


}
