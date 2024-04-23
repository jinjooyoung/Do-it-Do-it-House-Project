using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    public int direction;   // 0 ����, 1 ����, 2 ����, 3 ����    
    //public Transform exitDoor;
    public Transform mainCamTransform;

    public float offSetNSCharater = 1.5f;
    public float offSetNSCamera = 10f;
    public float offSetEWCharater = 2.53f;
    public float offSetEWCamera = 20f;

    void Start()
    {
        mainCamTransform = FindObjectOfType<Camera>().transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")  //�ε��� ������Ʈ�� �±װ� �÷��̾��� ��
        {

            Debug.Log("�浹 ����!~");
            if (direction == 0)
            {
                Debug.Log("���� ����!~");
                other.transform.position += new Vector3(0, offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, offSetNSCamera, 0f);
            }
            else if (direction == 2)
            {
                other.transform.position += new Vector3(0, -offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, -offSetNSCamera, 0f);
            }
            else if (direction == 1)
            {
                Debug.Log("���� ����!~");
                other.transform.position += new Vector3(offSetEWCharater, 0f, 0);
                mainCamTransform.position += new Vector3(offSetEWCamera, 0f, 0f);
            }
            else if (direction == 3)
            {
                Debug.Log("���� ����!~");
                other.transform.position += new Vector3(-offSetEWCharater, 0f, 0f);
                mainCamTransform.position += new Vector3(-offSetEWCamera, 0f, 0f);
            }
        }
    }
}
