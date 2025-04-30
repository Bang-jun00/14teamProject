using System.Collections;
using UnityEngine;

public class Axeskill : MonoBehaviour
{
    [SerializeField] GameObject axePrefab; // ���� ������
    [SerializeField] Transform startpoint;
    [SerializeField] Axe Axe; // ���� ��ũ��Ʈ
    [SerializeField] public float AxeAttackDuration = 5f; //���� ���ӽð�
    [SerializeField] public float AxeAttackDelay = 0.5f; //���� ������

    WaitForSeconds axedelay = new WaitForSeconds(0.5f);
    public Vector2 vector2; // ���� ����?
    public void Start()
    {
        axedelay = new WaitForSeconds(AxeAttackDelay);
        //if(Input.GetKeyDown(KeyCode.Space)) // �����̽��ٸ� �������� ���� �߻�

        StartCoroutine(Thorwaxe()); // ���� �߻� �ڷ�ƾ ����
        

        
        //StartCoroutine(Thorwaxe()); // ���� �߻� �ڷ�ƾ ����
    }
    public void Update()
    {
        

    }
    private IEnumerator Thorwaxe()
    {
        while (true)
        {
            yield return axedelay; // 0.5�� ��� //?? �׳� �־���;; 
            
            shoot(); // ���� �߻� �Լ� ȣ��  //�ڷ�ƾ �ȿ���. �ݺ� �����ϰ� �Ұ�.
        }
    }
    private void shoot()
    {
        
        //axe���� ������ٵ� �����ͼ� �Ұ�. 
            Rigidbody2D rb =   Instantiate(axePrefab).GetComponent<Rigidbody2D>(); // ���� ������ٵ� ��������
        
        rb.transform.position = startpoint.position; // ���� ��ġ ����
            vector2 = new Vector2(Random.Range(-Axe.AxeAttackrandomAngle, Axe.AxeAttackrandomAngle), 100).normalized; //���� ���� ����
            rb.AddForce(vector2 * Axe.AxeThrowSpeed, ForceMode2D.Impulse); //���� ���� ����
            //rb.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25f, 25f)); // ���� ���� ����
            //rb.AddForce(startpoint.up * 10f, ForceMode2D.Impulse); // ���� �߻�
            Destroy(rb.gameObject, AxeAttackDuration); // 5�� �� ���� ����   // shoot�ȿ���. ���ٰ�.

    }
}








