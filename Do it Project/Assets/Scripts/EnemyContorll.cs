using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContorll : MonoBehaviour
{
    public LayerMask whatIsTarget; //������� ���̾�
    private NavMeshAgent pathFinder; //��� ��� AI ������Ʈ

    private Animator enemyAnimator; // �� ���ϸ��̼�

    public float damage = 20f; //���ݷ�
    public float attackDelay = 1f;  //���� ������
    private float lastAttackTime; // ������ ���� ����
    private float dist;     // ���������� �Ÿ�

    public Transform tr;

    //private float attackRange = 2.3f;

    private bool hasTarget
    {
        get
        {
            //������ ����� �����ϰ�, ����� ������� �ʾҴٸ� true
           // if (targetEntity != null && !targetEntity.dead)
            {
                return true;
            }

            //�׷��� �ʴٸ� false
            //return false;
        }
    }

    private bool canMove;
    private bool canAttack;

}



