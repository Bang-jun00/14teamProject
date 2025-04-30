using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public int id; //�ش� ������ ���̵�
    public int prefabid; //�ش� ������ ������
    public float damage = 10f; //������
    public int weaponlevel;
    public float attackSpeed = 1f; //���ݼӵ�

    private void Start()
    {
        Init();
    }
    private void Update()
    {
        
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                attackSpeed = -150;
                rollattack();
                break;
            default:
                break;
        }
    }

    void rollattack()
    {
        //ȸ�� ����
        //ȸ�� ������ ���� �ڵ� �ۼ�
        for(int i =0; i < weaponlevel; i++)
        {
            Transform spinball = WeaponManager.instance.weaponPool.Get(prefabid).transform; //���� Ǯ���� ���� ��������
            spinball.parent = transform; //�θ� ����
            spinball.GetComponent<spinfireball>().Init(damage, -1); //  -1 ���� �����Ͻ��� ������.
            //ȸ�� ������ ���� �ڵ� �ۼ�
        }
    }
}
