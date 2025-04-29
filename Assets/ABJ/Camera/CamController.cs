using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Transform target;
    void Start()
    {
        target = FindObjectOfType<PlayerStats>().transform;
    }

    
    void LateUpdate()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        //카메라 x, y의 포지션은 따라가게, z위치를 고정
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
