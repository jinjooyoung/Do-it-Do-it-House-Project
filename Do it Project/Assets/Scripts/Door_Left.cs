using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Left : MonoBehaviour
{
    public Transform exitDoor;
    //public Transform roomNumber;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")  //�ε��� ������Ʈ�� �±װ� �÷��̾��� ��
        {
            other.transform.position = exitDoor.position + new Vector3 (-1.5f, 0, 0);
            
        }
    }
}
