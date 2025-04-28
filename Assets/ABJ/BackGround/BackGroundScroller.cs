using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroller : MonoBehaviour
{
    public Transform playerPostion; //플레이어 오브젝트의 위치.
    public Transform[] backgrounds; //배경 타일맵 위치를 담을 배열 3x3 총 9개
    public Vector2 backgroundSize; //배경 타일맵 하나의 크기

    void Update()
    {
        foreach (Transform backgroundPosition in backgrounds)
        {
            float distanceX = Mathf.Abs(playerPostion.position.x - backgroundPosition.position.x); //배경과 플레이어 사이의 x좌표 거리 계산
            float distanceY = Mathf.Abs(playerPostion.position.y - backgroundPosition.position.y); //배경과 플레이어 사이의 y좌표 거리 계산

            // 만약 배경이 너무 멀어지면
            if(distanceX > backgroundSize.x)
            {
                //x축으로 배경 옮겨주기
                float move = (playerPostion.position.x > backgroundPosition.position.x) ? backgroundSize.x * 3f : -backgroundSize.x * 3f;
                backgroundPosition.position += new Vector3(move, 0f, 0f);
            }

            if(distanceY > backgroundSize.y)
            {
                //y축으로 배경 옮겨주기
                float move = (playerPostion.position.y > backgroundPosition.position.y) ? backgroundSize.y * 3f : -backgroundSize.y * 3f;
                backgroundPosition.position += new Vector3(0f, move, 0f);
            }
        }
    }
}
