using System.Collections;//
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int BlockIndex = 1;
    public float moveSpeed = 5f; // ���� �̵� �ӵ�
    public GameObject missilePrefab;
    public Transform player;
    public float fireRate = 1f; // �߻� �ӵ� (�ʴ� �߻� Ƚ��)
    public float fireTime = 0f;

    public GameManager gameManager;

    public Animator monsteranimator;
    private string currentAnimation = "";
    public GameObject slaimPf;
    public GameObject mousePf;
    public GameObject dogPf;
    bool isAniStart = false;
    //����
    public GameObject monsterAttack;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }
    void ChangeAnimation(string animation, float crossfade = 0.2f)  //�ִϸ��̼�!!
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            if (slaimPf != null) monsteranimator.CrossFade(animation, crossfade);
            if (mousePf != null) monsteranimator.CrossFade(animation, crossfade);
            if (dogPf != null) monsteranimator.CrossFade(animation, crossfade);
        }
    }

    void Update()
    {
        if (gameManager.PlayerBlockIndex != BlockIndex)
            return;

        isAniStart = true;
        if(isAniStart == true)
        {
           monsteranimator = GetComponent<Animator>();
        }
        // �÷��̾� �������� �̵�
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        if (transform.position.x < player.position.x)
        {
            ChangeAnimation("RightMove");
            if (slaimPf != null) monsteranimator.SetInteger("move", 1);
            if (mousePf != null) monsteranimator.SetInteger("move", 1);
            if (dogPf != null) monsteranimator.SetInteger("move", 1);
        }
        if (transform.position.x > player.position.x)
        {
            ChangeAnimation("LeftMove");
            if (slaimPf != null) monsteranimator.SetInteger("move", 2);
            if (mousePf != null) monsteranimator.SetInteger("move", 2);
            if (dogPf != null) monsteranimator.SetInteger("move", 2);
        }
        fireTime += Time.deltaTime;

        if(fireTime >= fireRate)
        {
            Shoot();
            fireTime = 0.0f;
        }
    }

    void Shoot()
    {
        monsterAttack.GetComponent<AudioSource>().Play();
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
