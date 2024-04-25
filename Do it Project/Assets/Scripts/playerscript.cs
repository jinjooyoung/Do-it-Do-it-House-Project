 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum Type { Melee, Eange }
public class playerscript : MonoBehaviour
{
    public float speed;
    public int itemCount;
    public float attackTime = 0.3f;          // ���� ��Ÿ��
    public float attackTimer;                   // ���� ��Ÿ�� ����
    public bool isAttack;
    public Type weaponType = Type.Melee;
    public BoxCollider attackArea;
    float hAxis;
    float vAxis;

    /*bool WDown;
    bool jump;


    bool isJump;    //��� ����*/

    Vector3 moveVec;

    Rigidbody rb; // �ɸ��͸� �����̱� ���� ����
    //Animator anim;

    GameObject nearObject;

    void Awake()
    {
        rb = GetComponent<Rigidbody>(); //������ٵ� ������Ʈ�� rb�Ҵ�
        attackArea = GetComponent<BoxCollider>();
        attackArea.enabled = false;
        //anim = GetComponentInChildren<Animator>();  //�ִϸ����� ������Ʈ�� anim�Ҵ�
    }
    void Update()
    {
        GetInput();
        Move();
        Turn();
        //Jump();
        Attack();
        //�Լ� �ҷ����� (�ؿ� �Լ�)
    }


    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        /*WDown = Input.GetButton("wolk");
        jump = Input.GetButtonDown("Jump");*/

        //Axis�� �ҷ��ͼ� ������ ����

    }
    

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;  //�������� �̵� ����

        transform.position += moveVec * speed * Time.deltaTime; //����

     //   anim.SetBool("isRun", moveVec != Vector3.zero);     //�̵��ӵ��� zero�� �ƴ� �� �̵� �ִϸ��̼�
        //anim.SetBool("isWolk", WDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);     //���� ȭ������ ȸ��
    }

    private void Attack()
    {
        if(weaponType == Type.Melee)
        {
            attackArea.enabled = isAttack;
        }
        else if(weaponType == Type.Eange)
        {
            //Eange();
        }


        if (isAttack == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isAttack = true;
                attackTimer = attackTime;
            }
        }
        else // isAttack == true
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                isAttack = false;
            }
        }
    }

    //ž�� �����̶� ������ ����

    /*void Jump() // ����
    {
        if (jump && !isJump) // ! ������ bool ���� ����
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            anim.SetBool("triggerJump", true);
            isJump = true;
        }
    }*/


   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            anim.SetBool("triggerJump", false);
            isJump = false;
        }
    }*/


}