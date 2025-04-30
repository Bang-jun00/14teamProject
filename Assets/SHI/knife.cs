using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    //데미지
    //관통력
    public float damage = 10f;
    public int sharpness = 5;

    public void Init(float damage, int sharpness)
    {
        this.damage = damage;
        this.sharpness = sharpness;
    }
}
