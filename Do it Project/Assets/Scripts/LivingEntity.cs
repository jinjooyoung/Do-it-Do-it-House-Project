using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    public float startingHealth = 100f;//���� ü��
    public float startingMana = 0f;//���� ����

    // protected Ŭ���� �ܺο����� �⺻������ ������ �� ������ �Ļ� Ŭ����(�ڽ� Ŭ����)������ ������ �����ϴ�.
    public float health {  get; protected set; } //���� ü��  
    public float mana { get; protected set; }   // ���� ����
    public bool dead {  get; protected set; } // ��� ����  

    //����ü�� Ȱ��ȭ�� �� ���¸� ����
    // virtual ����
    protected virtual void OnEnable()
    {
        //������� ���� ���·� ����
        dead = false;
         //ü���� ���� ü������ �ʱ�ȭ
        health = startingHealth;
        mana = startingMana;
    }

    // ���ظ� �޴� ���
    public virtual void OnEnable(float damage)
    {
        health -= damage;

        if(health <= 0 && !dead)
        {
            Die();
            Debug.Log("���� óġ �߽��ϴ�.");
        }
    }

    //���ó��
    public virtual void Die()
    {
        //onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
     //  if (onDeath != null) �� ��� �� ���
        {
     //       onDeath();
        }
        dead = true;
    }
}
