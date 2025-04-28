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

    [SerializeField]public float AxeDamage = 10f;   //���ݷ�
    [SerializeField]public float AxeAttackRange = 1f; //���ݹ���
    [SerializeField]public float AxeAttackDuration = 5f; //���� ���ӽð�
    [SerializeField]public float AxeAttackDelay = 0.5f; //���� ������
    [SerializeField]public float AxeThrowSpeed = 1f; //���ݼӵ�
    [SerializeField]public float AxeAttackrandomAngle = 45f;    //���� ����
    [Range(0,5)]
    [SerializeField]public int Axelevel = 1; //���� ����
    [SerializeField]public CircleCollider2D AxeAttackRangeCollider; //���� ���� �ݶ��̴�

    WaitForSeconds axedelay = new WaitForSeconds(0.5f); //������ �ð� ����

    public List<GameObject> Axeslot = new List<GameObject>(); //���� ���� ����Ʈ
    public GameObject AxePrefab; //���� ������
    public float axeattackdelay;
    public void Start()
    {
        axedelay = new WaitForSeconds(AxeAttackDuration); //������ �ð� ����
        AxeAttackRangeCollider.radius = AxeAttackRange; //���� ���� ����

        for (int i = 0; i < 5; i++)
        {
            GameObject axe = Instantiate(AxePrefab); //���� ������ ����
            Axeslot.Add(axe); //���� ���� ����Ʈ�� �߰�
            axe.SetActive(false); //���� ��Ȱ��ȭ
           // gameObject.SetActive(false); //���� ��Ȱ��ȭ
        }

    }
    public void OnEnable()
    {
       
        
        
            //������ ������ �Լ�
            StartCoroutine(ThrowAxe());
        
    }

    IEnumerator ThrowAxe()
    {
        
        for (int i = 0; i < Axelevel; i++)
        {
            GameObject axe = Axeslot[i]; //���� ���� ����Ʈ���� ���� ��������
            axe.SetActive(true); //���� Ȱ��ȭ
            axe.transform.position = transform.position; //���� ��ġ ����
            Rigidbody2D rb = axe.GetComponent<Rigidbody2D>(); //���� ������ٵ� ��������
            rb.AddForce(transform.up * AxeThrowSpeed, ForceMode2D.Impulse); //���� ���� ������
            
            yield return axedelay; //���� ���ӽð� ���
            rb.velocity = Vector2.zero; //���� �ӵ� �ʱ�ȭ
            axe.SetActive(false); //���� ��Ȱ��ȭ
        }
    }
















}
