using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{

    //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    void OnTriggerStay(Collider other)
    {    //�浹�� ���� ���� ������Ʈ�� player �±׸� ���� ���
        if (other.tag == "Monster")
        {
            //���� ���� ������Ʈ���� playerController ������Ʈ ��������
            Monster monster = other.GetComponent<Monster>();


            if (monster != null)
            {

                monster.Die();
            }
        }
    }


}
