using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour
{
    public int HealthPoint;
    public Animator playeranimator;
    public GameObject UI;
    bool isheal = false;
    bool isEnd = false;
    bool isEnd2 = false;
    //���� ����
    public GameObject hurtSound;
    void Start()
    {
        playeranimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isheal == true)
        {
            HealthPoint = 10;
            UI.gameObject.GetComponent<UIManager>().Heal();
            isheal = false;
        }
    }

    public void TakeDamage(int amount)
    {
        hurtSound.GetComponent<AudioSource>().Play();
        if (amount > 0)
        {
            HealthPoint -= amount;
            playeranimator.SetTrigger("Hurt");  //�ִϸ��̼�
            if (UI != null)
            {
                UI.gameObject.GetComponent<UIManager>().actorHp = HealthPoint; //ü���� �پ��
                UI.gameObject.GetComponent<UIManager>().Hurt();
            }
        }
        if (HealthPoint == 0)
        {
            UI.gameObject.GetComponent<UIManager>().GameOver();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnd == false)
        {
            if (collision.gameObject.tag == "Heal")
            {
                isheal = true;
                isEnd = true;
            }
        }         
        if (isEnd2 == false)
        {
            if (collision.gameObject.tag == "Heal2")
            {
                isheal = true;
                isEnd2 = true;
            }
        } 

    }

}