using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    //������
    //�����
    public float damage = 10f;
    public int sharpness = 5;

    public void Init(float damage, int sharpness)
    {
        this.damage = damage;
        this.sharpness = sharpness;
    }
}
