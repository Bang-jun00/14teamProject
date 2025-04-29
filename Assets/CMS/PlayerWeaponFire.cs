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
            Debug.LogError("발사 지점이 설정 되지 않았습니다.");
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
                weapon.transform.position = weaponFirePoint.position; // 발사 지점으로 위치 옮기기
                weapon.SetActive(true); // 무기 활성화 -> 무기가 알아서 동작 시작
            }
        }
    }
}
