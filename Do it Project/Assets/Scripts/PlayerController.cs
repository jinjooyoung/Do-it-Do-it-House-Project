using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab;

    private Rigidbody2D rb;
    public Animator animator;                   //�ִϸ��̼�!!
    private string currentAnimation = "";       //�ִϸ��̼�!!

    private bool isShooting = false;
    private float shootTimer = 0f;
    public float shootInterval = 0.3f; // ����ü �߻� ���� (��)

    private Vector2 shootDirection = Vector2.zero;

    public GameManager gameManager;
    public bool isPlayingSequence = false;
    public bool isBlockMoveSequence = false;
    public int MoveTemp = 0;
    bool isAni = false;
    public GameObject UIManager;

    Vector2 moveDirection;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();   //�ִϸ��̼�!!
    }

    void ChangeAnimation(string animation, float crossfade = 0.2f)  //�ִϸ��̼�!!
    {
        if(currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }
    }

    private void Update()
    {
        if (isPlayingSequence)
            return;

        // �÷��̾� �̵�
        moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) moveDirection.x = -1;

        else if (Input.GetKey(KeyCode.D)) moveDirection.x = 1;
        
        if (Input.GetKey(KeyCode.W)) moveDirection.y = 1;
        
        else if (Input.GetKey(KeyCode.S)) moveDirection.y = -1;
        //�̵�Ű�� �ϳ��� ������ ���
        if(moveDirection.x == -1 && moveDirection.y != -1 && moveDirection.y != 1) ChangeAnimation("LeftMove");
        if(moveDirection.x == 1 && moveDirection.y != -1 && moveDirection.y != 1) ChangeAnimation("RightMove");
        if (moveDirection.y == -1 && moveDirection.x != -1 && moveDirection.x != 1) ChangeAnimation("FrontMove");
        if (moveDirection.y == 1 && moveDirection.x != -1 && moveDirection.x != 1) ChangeAnimation("BackMove");
        //�̵�Ű�� �ΰ��� ���� ������ ���
        if (moveDirection.x == 1 && moveDirection.y == -1) ChangeAnimation("RightMove");
        if (moveDirection.x == 1 && moveDirection.y == 1) ChangeAnimation("RightMove");
        if (moveDirection.y == -1 && moveDirection.x == -1) ChangeAnimation("LeftMove");
        if (moveDirection.y == 1 && moveDirection.x == -1) ChangeAnimation("LeftMove");
        //�ΰ��� ����Ű�� ������ ����� ��������

            rb.velocity = moveDirection.normalized * moveSpeed;

        // ����ü �߻�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartShooting(Vector2.left);
            animator.SetBool("LeftAttack", true);
            animator.SetBool("RightAttack", false);
            animator.SetBool("BackAttack", false);
            animator.SetBool("FrontAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartShooting(Vector2.right);
            animator.SetBool("RightAttack", true);
            animator.SetBool("LeftAttack", false);
            animator.SetBool("BackAttack", false);
            animator.SetBool("FrontAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartShooting(Vector2.up);
            animator.SetBool("BackAttack", true);
            animator.SetBool("LeftAttack", false);
            animator.SetBool("RightAttack", false);
            animator.SetBool("FrontAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartShooting(Vector2.down);
            animator.SetBool("FrontAttack", true);
            animator.SetBool("LeftAttack", false);
            animator.SetBool("RightAttack", false);
            animator.SetBool("BackAttack", false);
        }

        // ȭ��ǥ Ű�� ������ �ʾ��� �� �߻� ����
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            StopShooting();
        }
        if((moveDirection.x != 1 && moveDirection.x != -1 && moveDirection.y != 1 && moveDirection.y!= -1 && !Input.GetKey(KeyCode.LeftArrow) 
            && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)))
        {
            ChangeAnimation("Idle");
        }
        //�̵��� ������ ���� �ϰ� ���� ������ ������ ���� ��������
        if(shootDirection.x == -1 && moveDirection.x == -1 )
        {
            if (isAni == false && moveDirection.x == -1)
            {
                //ChangeAnimation("Idle(2)");
            }
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
        isAni = true;
        shootDirection = direction; // �߻� ���� ����
        shootTimer = 0f; // �Ѿ��� �ٷ� �߻�ǵ��� Ÿ�̸� �ʱ�ȭ
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(shootDirection.x, shootDirection.y, 0) * 0.2f, Quaternion.identity);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectile.GetComponent<Bullet>().bullettype = Bullet.BULLETTYPE.PLAYER;
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
        isAni = false;
        shootTimer = 0f;
        animator.SetBool("LeftAttack", false);
        animator.SetBool("RightAttack", false);
        animator.SetBool("BackAttack", false);
        animator.SetBool("FrontAttack", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.tag == "Door")
        {
            DoorObject temp = collision.gameObject.GetComponent<DoorObject>();
            if(temp != null)
            {
                if(temp.DoorBlockIndex == gameManager.PlayerBlockIndex)
                {                   
                    Invoke("MoveIndexSet", 2.0f);
                    MoveTemp = temp.MoveToIndex;
                    StartMovingTowardsTarget(gameManager.MapBlock[MoveTemp].transform);
                    gameManager.MoveBlock(temp.MoveToIndex);
                    isPlayingSequence = true;
                    isBlockMoveSequence = true;
                }               
            }
            else
            {
                Debug.LogError("Door ������Ʈ�� ����");
            }
        }
       /* if (collision.gameObject.tag == "Trap")  //������ ����
        {
            UIManager.gameObject.GetComponent<UIManager>().GotoBoss();
        }*/
    }

    // ���� ���� �� ȣ���� �Լ�
    public void StartMovingTowardsTarget(Transform target)
    {
        // ��ǥ ��ġ�� 1/5 ��ġ�� ����մϴ�.
        Vector3 destination = Vector3.Lerp(transform.position, target.position, 0.3f);

        // DOTween�� ����Ͽ� �ε巴�� ��ǥ ��ġ�� 1/5 ��ġ�� �̵��մϴ�.
        transform.DOMove(destination, 1.0f).SetEase(Ease.Linear);
    }

    public void MoveIndexSet()
    {
        gameManager.PlayerBlockIndex =  MoveTemp;
        isPlayingSequence = false;
        isBlockMoveSequence = false;
;
    }

    public void Die()
    {
        Debug.Log("�÷��̾� ���");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pond")
        {
            UIManager.gameObject.GetComponent<UIManager>().Clear();
        }
    }
}

