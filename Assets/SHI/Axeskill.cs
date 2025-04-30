using System.Collections;
using UnityEngine;

public class Axeskill : MonoBehaviour
{
    [SerializeField] GameObject axePrefab; // 도끼 프리팹
    [SerializeField] Transform startpoint;
    [SerializeField] Axe Axe; // 도끼 스크립트
    [SerializeField] public float AxeAttackDuration = 5f; //공격 지속시간
    [SerializeField] public float AxeAttackDelay = 0.5f; //공격 딜레이

    WaitForSeconds axedelay = new WaitForSeconds(0.5f);
    public Vector2 vector2; // 도끼 각도?
    public void Start()
    {
        axedelay = new WaitForSeconds(AxeAttackDelay);
        //if(Input.GetKeyDown(KeyCode.Space)) // 스페이스바를 눌렀을때 도끼 발사

        StartCoroutine(Thorwaxe()); // 도끼 발사 코루틴 시작
        

        
        //StartCoroutine(Thorwaxe()); // 도끼 발사 코루틴 시작
    }
    public void Update()
    {
        

    }
    private IEnumerator Thorwaxe()
    {
        while (true)
        {
            yield return axedelay; // 0.5초 대기 //?? 그냥 넣어짐;; 
            
            shoot(); // 도끼 발사 함수 호출  //코루틴 안에서. 반복 실행하게 할것.
        }
    }
    private void shoot()
    {
        
        //axe값의 리지드바디를 가져와서 할것. 
            Rigidbody2D rb =   Instantiate(axePrefab).GetComponent<Rigidbody2D>(); // 도끼 리지드바디 가져오기
        
        rb.transform.position = startpoint.position; // 도끼 위치 설정
            vector2 = new Vector2(Random.Range(-Axe.AxeAttackrandomAngle, Axe.AxeAttackrandomAngle), 100).normalized; //도끼 각도 설정
            rb.AddForce(vector2 * Axe.AxeThrowSpeed, ForceMode2D.Impulse); //랜덤 각도 설정
            //rb.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-25f, 25f)); // 랜덤 각도 설정
            //rb.AddForce(startpoint.up * 10f, ForceMode2D.Impulse); // 도끼 발사
            Destroy(rb.gameObject, AxeAttackDuration); // 5초 후 도끼 삭제   // shoot안에서. 해줄것.

    }
}








