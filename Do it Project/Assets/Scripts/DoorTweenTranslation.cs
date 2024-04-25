using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class DoorTweenTranslation : MonoBehaviour
{
    public int direction;   // 0 ����, 1 ����, 2 ����, 3 ����    
    //public Transform exitDoor;
    public Transform mainCamTransform;
    public float duration = 1.0f;
    public Ease ease;

    public float offSetNSCharater = 1.5f;       // ���Ʒ� ĳ���� �̵� �Ÿ�    
    public float offSetNSCamera = 10f;          // ���Ʒ� ī�޶� �̵� �Ÿ�
    public float offSetEWCharater = 2.53f;      // �¿� ĳ���� �̵� �Ÿ� 
    public float offSetEWCamera = 20f;          // �¿� ī�޶� �̵� �Ÿ�
    //public float cameraPosition;

    void Start()
    {
        mainCamTransform = FindObjectOfType<Camera>().transform;
        //cameraPosition = Camera.transform.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")  //�ε��� ������Ʈ�� �±װ� �÷��̾��� ��
        {
            if (direction == 0) // ����
            {
                other.transform.position += new Vector3(0, offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, offSetNSCamera, 0f);
            }
            else if (direction == 2)    // ����
            {
                other.transform.position += new Vector3(0, -offSetNSCharater, 0);
                mainCamTransform.position += new Vector3(0f, -offSetNSCamera, 0f);
            }
            else if (direction == 1)    // ����
            {
                other.transform.position += new Vector3(offSetEWCharater, 0f, 0);
                //mainCamTransform.position += new Vector3(offSetEWCamera, 0f, 0f);
                mainCamTransform.DOMoveX(0, duration, false).SetEase(ease);
                //mainCamTransform.DOMoveX(new Vector3(-offSetEWCamera, 0f, 0f), 0.5f).SetEase(ease);
            }
            else if (direction == 3)    // ����
            {
                other.transform.position += new Vector3(-offSetEWCharater, 0f, 0f);
                //mainCamTransform.position += new Vector3(-offSetEWCamera, 0f, 0f);                
                mainCamTransform.DOMoveX(-offSetEWCamera, duration, false);


            }
        }
    }
}
