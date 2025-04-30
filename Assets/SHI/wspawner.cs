using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wspawner : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            WeaponManager.instance.weaponPool.Get(0);
        }
    }


}
