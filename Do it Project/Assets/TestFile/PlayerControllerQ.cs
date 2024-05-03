using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerQ : MonoBehaviour
{
    public float speed = 8.0f;
    public float attackRange = 1f;      // ���� �ݶ��̴��� �÷��̾ �������� �󸶳� �������� ������ ������ �� �Ÿ��� ���� ���� (��, ���� �Ÿ�)
    public float attackCooldown = 1.0f;   //���� ��Ÿ�� (���Ƿ� �����ص�)
    public GameObject attackPrefab; // Ÿ�� �ݶ��̴��� ����� ������

    private float curTime = 0f; // ���� ��ٿ� �ð�
    private Vector2 lastMoveDirection = Vector2.right; // �÷��̾��� ������ �̵� ����, �⺻���� ������
    private Rigidbody2D rb;
    private Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, ySpeed, 0);
        rb.velocity = newVelocity;      //���� �� �̵� ���� �ڵ�

        // �÷��̾��� ������ �̵� ���� ������Ʈ
        if (xSpeed != 00 || ySpeed != 00)   //�÷��̾��� ��ġ�� 0�� �ƴ� ��. �� �̵��Ͽ��� ��
        {
            lastMoveDirection = newVelocity.normalized;   
          
        }

        // ���� ��ٿ� ���� �� �Է� ó��
        if (curTime > 0) 
        {
            curTime -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0))      
        {
            // Ÿ�� �ݶ��̴� ����
            GameObject attack= Instantiate(attackPrefab, 
                transform.position + (Vector3)lastMoveDirection * attackRange, Quaternion.identity);
            //���� ������ BulletSpawner�ڵ� ����
            Destroy(attack, 15* Time.deltaTime);


            // ���� ��ٿ� ����
            curTime = attackCooldown;
            //������ �������� ��Ÿ���� �ο��������
        }
    }
}

