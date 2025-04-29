using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [Header("대시 설정")]
    [SerializeField] private float dashDuration; // 대시가 유지되는 시간 
    [SerializeField] private float dashSpeed; // 대시 중 이동 속도
    [SerializeField] private float dashCooldownTime; // 대시 후 재사용 시간
   
    private float dashCoolTime = 0f; // 현재 남은 쿨타임 시간
    private float dashTimer = 0f; // 현재 대시 중 남은 시간


    private bool isDashing = false; // 현재 대시 상태인지 여부

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
    } 

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // 대시 시작 조건: Shift 키를 누르고, 대시 중이 아니며, 쿨타임이 끝났을 때
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dashCoolTime <= 0)
        {
            isDashing = true;
            dashTimer = dashDuration;
            dashCoolTime = dashCooldownTime;
        }

        if(isDashing)
        {
            dashTimer -= Time.deltaTime; // 매 프레임마다 대시 시간 줄이기
            if (dashTimer <= 0f)
            {
                isDashing = false;   // 대시 종료
            }
        }

        if(dashCoolTime > 0f)
        {
            dashCoolTime -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // 이동 속도 설정: 대시 중이면 dashSpeed, 아니면 기본 이동 속도
        float speed = isDashing ? dashSpeed : playerStats.CurrentMoveSpeed;
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
