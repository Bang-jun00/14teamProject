using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    //������ ���� ���󰣴� ������ -45~45��
    //������ ���󰡴� �ӵ��� �ʿ��ϸ� 
    //������ ���󰡴� ������ �������� �����Ѵ�
    //���� �ֱ�, ���ݷ�, ���ݹ���, ���� ���ӽð�, ���� ������, ���ݼӵ�, ���� ����
    //�� �ʿ��ϴ�. ������ٵ� ���� ���ſ��� �Ѵ�. ��� ���͸�  �հ� �������� �Ѵ�.
    //������ ó���� ������ �ӵ��� �ְ� �������� �߷¿� ���� �ӵ��� �����ϸ� �������鼭 �ǰ�ü�� �ε����� �ӵ��� ���� ���� �پ���.
    //������. ���ݵ������� �ִ� ��Ŀ� ���� ���͸� ���� ����� ��� �����ؾ��ϳ�.
    //���� ���� ����ȭ�� ��� �Ұ��ΰ�.
    //���� ������ ���� �����Ҷ� ��� ������ �Ҽ� �ֳ� ����Ŭ �ݸ����� �����Ҽ� �ִµ�. �� ���� �ݸ������� ���������ʰ� ��ũ��Ʈ���� �����Ҽ� �ֳ�.

    [SerializeField] float AxeDamage = 10f;   //���ݷ�
    [SerializeField] float AxeAttackRange = 1f; //���ݹ���
    [SerializeField] float AxeAttackDuration = 5f; //���� ���ӽð�
    [SerializeField] float AxeAttackDelay = 0.5f; //���� ������
    [SerializeField] float AxeThrowSpeed = 1f; //���ݼӵ�
    [SerializeField] float AxeAttackrandomAngle = 45f;    //���� ����
    [Range(0,5)]
    [SerializeField] int Axelevel = 1; //���� ����
    [SerializeField] CircleCollider2D AxeAttackRangeCollider; //���� ���� �ݶ��̴�
    public void Start()
    {
      AxeAttackRangeCollider.radius = AxeAttackRange; //���� ���� ����
    }







}
