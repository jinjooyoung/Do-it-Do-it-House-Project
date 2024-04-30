using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerQ : MonoBehaviour
{
    public float speed = 8.0f;
    public float attackRange = 1.5f;      // ���� �ݶ��̴��� �÷��̾ �������� �󸶳� �������� ������ ������ �� �Ÿ��� ���� ���� (��, ���� �Ÿ�)
    public float attackCooldown = 1.0f;   //���� ��Ÿ�� (���Ƿ� �����ص�)
    public GameObject attackColliderPrefab; // Ÿ�� �ݶ��̴��� ����� ������

    private float curTime = 0f; // ���� ��ٿ� �ð�
    private Vector2 lastMoveDirection = Vector2.right; // �÷��̾��� ������ �̵� ����, �⺻���� ������
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        rb.velocity = newVelocity;      //���� �� �̵� ���� �ڵ�

        // �÷��̾��� ������ �̵� ���� ������Ʈ
        if (newVelocity != Vector2.zero)   //�÷��̾��� ��ġ�� 0�� �ƴ� ��. �� �̵��Ͽ��� ��
        {
            lastMoveDirection = newVelocity.normalized;   
            //���������� �̵��� ������ ������ ���� ������ lastMoveDirection�� newVelocity(�̵��Ҷ� ����� ����.
            //�� ���� �̵��� ��ġ��� �� �� ����)�� normalized(������ ����ȭ.
            //���� ���ؼ� 4/29 ���ӿ����� �Թ� �����ð��� ����� ���⺤�ͷ� ��ȯ����.
            //���� �� (3,0)���� �̵��ߴٰ� �Ѵٸ� (1,0)*3�̹Ƿ� ���⿡��(1,0)�� �ش��ϴ� �κ��� �����شٰ� �� �� ����.
            //���� ����ؼ� ���������� �̵��ߴ� ������ ������)
        }

        // ���� ��ٿ� ���� �� �Է� ó��
        if (curTime > 0)      //��Ÿ���� 0���� Ŭ ��. ��, ��Ÿ�ӿ� �ɷ����� �� = ������ ���ϴ� ��Ȳ�� ��
        {
            curTime -= Time.deltaTime;   // ��ŸŸ���� ���ָ鼭 ��Ÿ���� ���ҽ�Ŵ
        }
        else if (Input.GetMouseButtonDown(0))      
            //else�̹Ƿ� ��Ÿ���� 0���� �۰ų� ���� ��.
            //��, ��Ÿ�ӿ� �ɷ����� ���� �� = ������ ������ ��Ȳ�� �� + (���콺 ��Ŭ�� �Է��� �޾��� ��)
        {
            // Ÿ�� �ݶ��̴� ����
            GameObject attackCollider = Instantiate(attackColliderPrefab, 
                transform.position + (Vector3)lastMoveDirection * attackRange, Quaternion.identity);
            //���� ������ BulletSpawner�ڵ� ����

            Destroy(attackCollider, 1*Time.deltaTime); // 0.2�� �� Ÿ�� �ݶ��̴� �ı�      
            //������ ���ӵǴ� �ð� 0.2�ʷ� ���Ƿ� �����ص�. 0.2�� ���� ������ ����ǰ� �ݶ��̴��� ����� = ������ ����

            // ���� ��ٿ� ����
            curTime = attackCooldown;
            //������ �������� ��Ÿ���� �ο��������
        }
    }
}

