using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class playerscript : MonoBehaviour
{
    public float speed;
    public int itemCount;

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
        //anim = GetComponentInChildren<Animator>();  //�ִϸ����� ������Ʈ�� anim�Ҵ�

    }
    void Update()
    {
        GetInput();
        Move();
        Turn();
        //Jump();

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