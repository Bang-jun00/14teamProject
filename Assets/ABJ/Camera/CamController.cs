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
        //ī�޶� x, y�� �������� ���󰡰�, z��ġ�� ����
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
