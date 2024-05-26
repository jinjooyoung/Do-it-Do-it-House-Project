using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyController : MonoBehaviour
{
    public int BlockIndex = 1;
    public float moveSpeed = 5f; // ���� �̵� �ӵ�
    public GameObject missilePrefab;
    public Transform player;
    public float fireRate = 1f; // �߻� �ӵ� (�ʴ� �߻� Ƚ��)
    public float fireTime = 0f;

    public GameManager gameManager;

    public Animator monsteranimator;
    public GameObject slaimPf;
    public GameObject mousePf;
    public GameObject dogPf;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        monsteranimator = GetComponent<Animator>();

    }

    void Update()
    {
        // �÷��̾� �������� �̵�
        //transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        fireTime += Time.deltaTime;

        if (fireTime >= fireRate)
        {
            Shoot();
            fireTime = 0.0f;
        }
    }

    void Shoot()
    {
        // �̻��� �������� �ν��Ͻ�ȭ�Ͽ� �߻� ��ġ���� �����մϴ�.
        GameObject temp = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        // ������ �̻����� �÷��̾ ���� �߻��մϴ�.
        Vector2 direction = (player.position - transform.position).normalized;
        temp.GetComponent<Rigidbody2D>().velocity = direction; // �̻����� �ʱ� �ӵ� ����
        temp.GetComponent<Bullet>().bullettype = Bullet.BULLETTYPE.ENEMY;
        Destroy(temp, 10.0f);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
