using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject imageToShow; // Ȱ��ȭ�� �̹���

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))   //�÷��̾� �� ��ü �±� Ȯ��
        {
            imageToShow.SetActive(true);    //�̹��� Ȱ��ȭ
        }

        if (other.CompareTag("Player"))    //�÷��̾� �� ��ü �±� Ȯ��
        {
            imageToShow.SetActive(false);  //�̹��� ��Ȱ��ȭ
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Image()
    {
        Image.SetActive(false);
    }

}






//ó�� ����ȭ�� -> �ΰ��� ���� ���� �� ���� Ʃ�丮�� �� �����ϴ� �濡 ���� �ϴ� ��ũ��Ʈ Ʃ�丮�� �� �ڽ��ݶ��̴� �� ���� 

//���� ������ ��ŸƮ ���� �ΰ��� ���� Ʃ�丮�� �� �߰� ����� ��ũ��Ʈ �ۼ� ����

