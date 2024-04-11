// ���� ���Ⱑ ����� ���ϸ��̼� �۾��� ������ playerscipt�� ����

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{

    public enum Type { Melee, Eange } // ���� ���� ����Ʈ ���Ͽ� ����
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailRenderer;



    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }

    // IEnumerator : ������ �Լ� Ŭ����
    IEnumerator Swing()
    {
        // �߿��� ������ �ڷ�ƾ
        // ���� : Use() ���η�ƾ -> Swing() �����ƾ -> Use() ���η�ƾ (��������)
        // �ڷ�ƾ : Use() ���η�ƾ + Swing() �ڷ�ƾ Co - (���ý���)

        // yield : ����� �����ϴ� Ű����, ���� �� ����� �ð��� ���� ��������

        //1
        yield return new WaitForSeconds(0.1f); // 0.1 �� ���
        meleeArea.enabled = true;
        // trailEffect.enabled = true;

        //2
        yield return new WaitForSeconds(0.3f); // 0.3 �� ���
        meleeArea.enabled = false;

        //3
        yield return new WaitForSeconds(0.3f); // 0.3 �� ���
                                               // trailEffect.enabled = false;

        bool fDown; // ���ݹ�ư
        bool isFireReady = true; // ���ݰ��� ����

        Weapon equipWeapon; // GameObject -> Weapon ��ũ��Ʈ�� ����
        float fireDelay; // ���� ������ Ÿ��

        void Update()
        {
            Attack();
        }

        void GetInput()
        {
            fDown = Input.GetButtonDown("Fire1");
        }

        void Move()
        {
            // ���� �� ���� �� �������̰�
            //   if (isSwap || !isFireReady)
            //      moveVec = Vector3.zero;
        }

        // �̹� ��ũ��Ʈ �߿�κ�
        void Attack()
        {
            // ������ ���Ǹ� �÷��̾ �ΰ�, ���ݷ����� ���⿡ �����Ѵ�.
            if (equipWeapon == null)
                return;

            fireDelay += Time.deltaTime;
            isFireReady = equipWeapon.rate < fireDelay;

            //   if (fDown && isFireReady && !isDodge && !isSwap)
            {
                equipWeapon.Use();
                //   anim.SetTrigger("doSwing");
                fireDelay = 0;
            }

        }


        void Swap()
        {
            // equipWeapon�� GameObject -> Weapon���� �ٲ�⿡ ���缭 �ٲ��ݴϴ�


            // if ((sDown1 || sDown2 || sDown3) && !isJump && !isDodge)
            {
                if (equipWeapon != null)
                    equipWeapon.gameObject.SetActive(false);

                //   equipWeaponIndex = weaponIndex;

                // weapons[weaponIndex] -> weapons[weaponIndex].GetComponent<Weapon>();
                //  equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();

                // equipWeapon.SetActive(true) -> equipWeapon.gameObject.SetActive(true);
                equipWeapon.gameObject.SetActive(true);

                //   anim.SetTrigger("doSwap");


                // ���� ��
                //   isSwap = true;
                Invoke("SwapOut", 0.4f);

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerscript player = other.GetComponent<playerscript>(); // PlayerScript �� ����
    }

}