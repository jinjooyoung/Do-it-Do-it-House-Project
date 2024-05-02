using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class DoorTransition : MonoBehaviour
{
    public int direction;   // 0 ����, 1 ����, 2 ����, 3 ����
    public Transform mainCamTransform;
    private float duration = 0.3f;

    public float offSetNSCharater = 1.5f;       // ���Ʒ� ĳ���� �̵� �Ÿ�    
    public float offSetNSCamera = 10f;          // ���Ʒ� ī�޶� �̵� �Ÿ�
    public float offSetEWCharater = 2.53f;      // �¿� ĳ���� �̵� �Ÿ� 
    public float offSetEWCamera = 20f;          // �¿� ī�޶� �̵� �Ÿ�
    //public float cameraPosition;

    void Start()
    {
        mainCamTransform = FindObjectOfType<Camera>().transform;        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")  //�ε��� ������Ʈ�� �±װ� �÷��̾��� ��
        {
            if (direction == 0) // ����
            {
                other.transform.position += new Vector3(0, offSetNSCharater, 0);
                //mainCamTransform.position += new Vector3(0f, offSetNSCamera, 0f);
                mainCamTransform.DOMoveY(mainCamTransform.position.y + offSetNSCamera, 0f, false).SetEase(Ease.OutExpo);
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
                mainCamTransform.DOMoveX(mainCamTransform.position.x + offSetEWCamera, duration, false).SetEase(Ease.OutExpo);

            }
            else if (direction == 3)    // ����
            {
                other.transform.position += new Vector3(-offSetEWCharater, 0f, 0f);
                //mainCamTransform.position += new Vector3(-offSetEWCamera, 0f, 0f);
                mainCamTransform.DOMoveX(mainCamTransform.position.x - offSetEWCamera, duration, false).SetEase(Ease.OutExpo);
            }
        }
    }
}
