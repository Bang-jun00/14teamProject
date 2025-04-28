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

    [SerializeField] float AxeDamage = 10f;   //공격력
    [SerializeField] float AxeAttackRange = 1f; //공격범위
    [SerializeField] float AxeAttackDuration = 5f; //공격 지속시간
    [SerializeField] float AxeAttackDelay = 0.5f; //공격 딜레이
    [SerializeField] float AxeThrowSpeed = 1f; //공격속도
    [SerializeField] float AxeAttackrandomAngle = 45f;    //공격 각도
    [Range(0,5)]
    [SerializeField] int Axelevel = 1; //도끼 레벨
    [SerializeField] CircleCollider2D AxeAttackRangeCollider; //공격 범위 콜라이더
    public void Start()
    {
      AxeAttackRangeCollider.radius = AxeAttackRange; //공격 범위 설정
    }







}
