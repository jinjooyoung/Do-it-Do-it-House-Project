using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLazer : MonoBehaviour
{
    public float rotateSpeed = 0.1f;

    void Start()
    {
        
    }


    void Update()
    {
        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player") {

            print("�ɸ��� ���"); 
           Destroy(collision.gameObject);
        }
    }


}
