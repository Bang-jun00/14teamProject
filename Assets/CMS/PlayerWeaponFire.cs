using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponFire : MonoBehaviour
{
    public Transform weaponFirePoint;
    private List<GameObject> weapons = new List<GameObject>();
    
    private void Awake()
    {
        if (weaponFirePoint == null)
        {
            Debug.LogError("�߻� ������ ���� ���� �ʾҽ��ϴ�.");
        }

        GameObject[] foundWeapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in foundWeapons)
        {
            weapons.Add(weapon);
            weapon.SetActive(false);
        }
    }

    private void Start()
    {
        StartFiringWeapons();
    }

    private void StartFiringWeapons()
    {
        foreach (GameObject weapon in weapons)
        {
            if (weapon != null)
            {
                weapon.transform.position = weaponFirePoint.position; // �߻� �������� ��ġ �ű��
                weapon.SetActive(true); // ���� Ȱ��ȭ -> ���Ⱑ �˾Ƽ� ���� ����
            }
        }
    }
}
