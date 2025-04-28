using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    //도끼가 위로 날라간다 각도는 -45~45도
    //도끼가 날라가는 속도가 필요하며 
    //도끼가 날라가는 각도는 랜덤으로 설정한다
    //공격 주기, 공격력, 공격범위, 공격 지속시간, 공격 딜레이, 공격속도, 공격 각도
    //가 필요하다. 리지드바디가 아주 무거워야 한다. 모든 몬스터를  뚫고 지나가야 한다.
    //도끼를 처음에 던졋던 속도가 있고 내려갈땐 중력에 의해 속도가 증가하며 내려가면서 피격체오 부딛히며 속도가 아주 조금 줄어든다.
    //질문점. 공격데미지를 주는 방식에 대해 몬스터를 맡은 사람과 어떻게 조율해야하나.
    //공격 각도 랜덤화는 어떻게 할것인가.
    //공격 범위를 직접 정의할때 어떻게 연결을 할수 있냐 사이클 콜린더에 설정할수 있는데. 저 값을 콜린더에서 조정하지않고 스크립트에서 조정할수 있냐.

    [SerializeField]public float AxeDamage = 10f;   //공격력
    [SerializeField]public float AxeAttackRange = 1f; //공격범위
    [SerializeField]public float AxeAttackDuration = 5f; //공격 지속시간
    [SerializeField]public float AxeAttackDelay = 0.5f; //공격 딜레이
    [SerializeField]public float AxeThrowSpeed = 1f; //공격속도
    [SerializeField]public float AxeAttackrandomAngle = 45f;    //공격 각도
    [Range(0,5)]
    [SerializeField]public int Axelevel = 1; //도끼 레벨
    [SerializeField]public CircleCollider2D AxeAttackRangeCollider; //공격 범위 콜라이더

    WaitForSeconds axedelay = new WaitForSeconds(0.5f); //딜레이 시간 설정

    public List<GameObject> Axeslot = new List<GameObject>(); //도끼 슬롯 리스트
    public GameObject AxePrefab; //도끼 프리팹
    public float axeattackdelay;
    public void Start()
    {
        axedelay = new WaitForSeconds(AxeAttackDuration); //딜레이 시간 설정
        AxeAttackRangeCollider.radius = AxeAttackRange; //공격 범위 설정

        for (int i = 0; i < 5; i++)
        {
            GameObject axe = Instantiate(AxePrefab); //도끼 프리팹 생성
            Axeslot.Add(axe); //도끼 슬롯 리스트에 추가
            axe.SetActive(false); //도끼 비활성화
           // gameObject.SetActive(false); //도끼 비활성화
        }

    }
    public void OnEnable()
    {
       
        
        
            //도끼를 던지는 함수
            StartCoroutine(ThrowAxe());
        
    }

    IEnumerator ThrowAxe()
    {
        
        for (int i = 0; i < Axelevel; i++)
        {
            GameObject axe = Axeslot[i]; //도끼 슬롯 리스트에서 도끼 가져오기
            axe.SetActive(true); //도끼 활성화
            axe.transform.position = transform.position; //도끼 위치 설정
            Rigidbody2D rb = axe.GetComponent<Rigidbody2D>(); //도끼 리지드바디 가져오기
            rb.AddForce(transform.up * AxeThrowSpeed, ForceMode2D.Impulse); //도끼 위로 날리기
            
            yield return axedelay; //공격 지속시간 대기
            rb.velocity = Vector2.zero; //도끼 속도 초기화
            axe.SetActive(false); //도끼 비활성화
        }
    }
















}
