using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject SettingUI;
    public GameObject TutorialUI;
    bool isTut = false;
    float Timer = 0;
    public GameObject player;
    Rigidbody2D playerRb;
    public GameObject[] UIindex = new GameObject[10];
    public int actorHp;
    public GameObject cloud1;
    public GameObject cloud2;
    //����Ŭ�������
    public GameObject credit1;
    public GameObject credit2;
    public GameObject endPosition1;
    public GameObject endPosition2;
    public GameObject credit;
    float Timer2 = 0;
    bool isPlaying = false;
    bool isPlaying2 = false;
    //���ӿ�������
    public GameObject cloud_1;
    public GameObject cloud_2;
    public GameObject cloud_3;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainGameScene") //Ʃ�丮��â Ű�⼳��
        {
            isTut = true;
            TutorialUI.SetActive(true);
            playerRb = player.GetComponent<Rigidbody2D>();
            playerRb.simulated = false;
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainGameScene")  // Ʃ�丮��â ���⼳��
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Timer += Time.deltaTime;
                playerRb.simulated = true;
                TutorialUI.SetActive(false);
                player.SetActive(true);
                if (Timer >= 0.2f)
                    isTut = false;
            }

            if (Input.GetKeyUp(KeyCode.Escape) && isTut == false) //����â ����
            {
                SettingUI.SetActive(true);
                playerRb.simulated = false;
            }
        }
        if(SceneManager.GetActiveScene().name == "StartUI")  //����ȭ���� ����ִϸ��̼�
        {
           
            cloud1.transform.DOMoveX(300, 25f);
            cloud2.transform.DOMoveX(1280, 25f);
        }
        if(SceneManager.GetActiveScene().name == "GameClearUI") //�׷��� �ִϸ��̼�
        {
            credit.SetActive(true);
            isPlaying = true;
            credit1.transform.position = Vector2.MoveTowards(credit1.transform.position, endPosition1.transform.position, 0.7f);
            credit2.transform.position = Vector2.MoveTowards(credit2.transform.position, endPosition2.transform.position, 0.7f);
            if(isPlaying2 == true)
            {
                credit.SetActive(false);
                Timer2 = 0;
                isPlaying = false;

                if(Input.GetKey(KeyCode.Escape))
                    BackToStart();
            }
        }
        if (isPlaying == true)
        {
            Timer2 += Time.deltaTime;
        }
        if (Timer2 >= 48f)
        {
            isPlaying2 = true;
        }
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            cloud_1.transform.position = Vector2.MoveTowards(cloud_1.transform.position, new Vector2(1000,830), 0.1f);
            cloud_2.transform.position = Vector2.MoveTowards(cloud_2.transform.position, new Vector2(-60,320), 0.1f);
            cloud_3.transform.position = Vector2.MoveTowards(cloud_3.transform.position, new Vector2(1000, 172), 0.1f);
        }
    }
    public void Hurt()  //ĳ���Ͱ� �ǰݴ��� ��, �Ƿ��̹��� ����
    {
        if(actorHp % 2 == 1)
        {
            for(int i = 14; i >=10; i--)
            {
                if (i == actorHp / 2 + 10)
                {
                    UIindex[i].SetActive(false);
                    UIindex[i - 5].SetActive(true);
                }
            }
        }
        else if (actorHp % 2 == 0 && actorHp != 0)
        {
            for (int j = 9; j >= 6; j--)
            {
                if(j == actorHp / 2 + 5)  
                {
                    UIindex[j].SetActive(false);
                    UIindex[j - 5].SetActive(true);
                }
            }
        }
        if(actorHp == 0 )
        {
            UIindex[5].SetActive(false);
            UIindex[0].SetActive(true);
        }
    }

    public void StartGame() //���۾����� ���Ӿ����� �̵�
    {
        SceneManager.LoadScene("MainGameScene");
    }
    public void ExitGame() // ���۾����� ���ӳ�����
    {
//#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
//#else
        Application.Quit();
//#endif
    }
    public void OptionUI() // ���۾����� �ɼǾ����� �̵�
    {
        SceneManager.LoadScene("OptionUI");

    }
    public void BackToStart() // ����â���� ���۾����� �̵�
    {
        SceneManager.LoadScene("StartUI");
    }
    public void Continu()  // ����â ����
    {
        if (SceneManager.GetActiveScene().name == "MainGameScene")
            SettingUI.SetActive(false);
            playerRb.simulated = true;
    }
    public void Clear()
    {
        SceneManager.LoadScene("GameClearUI");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void GotoBoss()
    {
        //SceneManager.LoadScene("BossScenes",LoadSceneMode.Additive);
    }

}
