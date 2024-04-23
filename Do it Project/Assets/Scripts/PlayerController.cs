using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 8.0f;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�̵�
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float ySpeed = yInput * speed;

        Vector2 newVelocity = new Vector2(xSpeed, ySpeed); //2D �����̹Ƿ� Vector3�� �� �ʿ䰡 ����
        //������ٵ��� �ӵ��� newVelocity �Ҵ�
        rb.velocity = newVelocity;

        playerAnimator.SetFloat("HorizontalAxis", Input.GetAxis("Horizontal"));


        //if (rb.velocity.x! < 0)
        //{
        //    playerAnimator.SetBool("Walk_Left", true);
        //}
        //else
        //{
        //    playerAnimator.SetBool("Walk_Left", false);
        //}
    }
}
