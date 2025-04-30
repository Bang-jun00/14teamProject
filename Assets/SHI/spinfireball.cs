using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinfireball : MonoBehaviour
{
    public float damage ;
    public int sharpness  ;



    public void Init(float damage, int sharpness)
    {
        this.damage = damage;
        this.sharpness = sharpness;
    }
}
