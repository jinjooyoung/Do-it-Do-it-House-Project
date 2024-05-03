using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab;

    private Rigidbody2D rb;
    public Animator animator;

    private bool isShooting = false;
    private float shootTimer = 0f;
    public float shootInterval = 0.3f; // ����ü �߻� ���� (��)

    private Vector2 shootDirection = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // �÷��̾� �̵�
        Vector2 moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1;
        }

        rb.velocity = moveDirection.normalized * moveSpeed;

        // ����ü �߻�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartShooting(Vector2.left);
            animator.SetInteger("CharacterMoveState", 3);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartShooting(Vector2.right);
            animator.SetInteger("CharacterMoveState", 2);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartShooting(Vector2.up);
            animator.SetInteger("CharacterMoveState", 1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartShooting(Vector2.down);
            animator.SetInteger("CharacterMoveState", 0);
        }

        // ȭ��ǥ Ű�� ������ �ʾ��� �� �߻� ����
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            StopShooting();
        }


        // �߻� ���� üũ
        if (isShooting)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootInterval)
            {
                ShootProjectile();
                shootTimer = 0f;
            }
        }
    }

    void StartShooting(Vector2 direction)
    {
        isShooting = true;
        shootDirection = direction; // �߻� ���� ����
        shootTimer = 0f; // �Ѿ��� �ٷ� �߻�ǵ��� Ÿ�̸� �ʱ�ȭ
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(shootDirection.x, shootDirection.y, 0) * 0.2f, Quaternion.identity);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            if (projectileRb != null)
            {
                projectileRb.velocity = shootDirection * projectileSpeed;
            }
            Destroy(projectile, 1.0f);
        }
    }

    void StopShooting()
    {
        isShooting = false;
        shootTimer = 0f;
    }
}

