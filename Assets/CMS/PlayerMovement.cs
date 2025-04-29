using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [Header("��� ����")]
    [SerializeField] private float dashDuration; // ��ð� �����Ǵ� �ð� 
    [SerializeField] private float dashSpeed; // ��� �� �̵� �ӵ�
    [SerializeField] private float dashCooldownTime; // ��� �� ���� �ð�
   
    private float dashCoolTime = 0f; // ���� ���� ��Ÿ�� �ð�
    private float dashTimer = 0f; // ���� ��� �� ���� �ð�


    private bool isDashing = false; // ���� ��� �������� ����

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

        // ��� ���� ����: Shift Ű�� ������, ��� ���� �ƴϸ�, ��Ÿ���� ������ ��
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && dashCoolTime <= 0)
        {
            isDashing = true;
            dashTimer = dashDuration;
            dashCoolTime = dashCooldownTime;
        }

        if(isDashing)
        {
            dashTimer -= Time.deltaTime; // �� �����Ӹ��� ��� �ð� ���̱�
            if (dashTimer <= 0f)
            {
                isDashing = false;   // ��� ����
            }
        }

        if(dashCoolTime > 0f)
        {
            dashCoolTime -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        // �̵� �ӵ� ����: ��� ���̸� dashSpeed, �ƴϸ� �⺻ �̵� �ӵ�
        float speed = isDashing ? dashSpeed : playerStats.CurrentMoveSpeed;
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
