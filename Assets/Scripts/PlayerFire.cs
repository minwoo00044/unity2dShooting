using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// ��ǥ : ����� �Է�(Space)�� �޾� �Ѿ��� ����� �ʹ�.
//1. �Է¹ް�
//2. �Ѿ˻���

//��ǥ2 : �������� �Ծ��ٸ�, ��ų ������ �ö󰣴�.
//�Ӽ� : ��ų����
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;

    public AudioClip fireSound;
    // Update is called once per frame

    void Update()
    {
        //1. �Է� �ޱ�
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(skillLevel > 3)
                skillLevel = 3;
            // 2. �Ѿ� �����
            SoundManager.Instance.PlaySound(fireSound, 0.3f);
            ExcuteSkill(skillLevel);

        }
    }

    private void ExcuteSkill(int _skillLevel)
    {
        switch (_skillLevel)
        {
            case 0:
                ExcuteSkill_1();
                break;
            case 1:
                ExcuteSkill_2();
                break;
            case 2:
                ExcuteSkill_3();
                break;
            case 3:
                ExcuteSkill_4();
                break;

        }
        //�� ���� �Ѿ��� �߻� �ȴ�.
        void ExcuteSkill_1()
        {
            GameObject bulletGameObject = Instantiate(bullet);

            bulletGameObject.transform.position = gunPos.transform.position;
        }
        //�� ���� �Ѿ��� �߻�ȴ�.
        void ExcuteSkill_2()
        {

            GameObject bulletGameObject0 = Instantiate(bullet);
            GameObject bulletGameObject1 = Instantiate(bullet);
            bulletGameObject0.transform.position = gunPos.transform.position + new Vector3(-0.5f, 0, 0);
            bulletGameObject1.transform.position = gunPos.transform.position + new Vector3(0.5f, 0, 0);
        }

        void ExcuteSkill_3()
        {

            //ȸ�� ȸ����

            GameObject bulletGameObject0 = Instantiate(bullet);
            GameObject bulletGameObject1 = Instantiate(bullet);
            GameObject bulletGameObject2 = Instantiate(bullet);
            bulletGameObject0.transform.position = gunPos.transform.position + new Vector3(-0.3f, 0, 0);
            bulletGameObject1.transform.position = gunPos.transform.position + new Vector3(0.0f, 0, 0);
            bulletGameObject2.transform.position = gunPos.transform.position + new Vector3(0.3f, 0, 0);

        }

        void ExcuteSkill_4()
        {
            GameObject[] bullets = new GameObject[30];
            for(int i = 0; i < 24; i++) 
            {
                bullets[i] = Instantiate(bullet);
                bullets[i].transform.position = gunPos.transform.position;
                bullets[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 15f * i));
            }
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item" && skillLevel < 3)
        {
            skillLevel++;
        }
    }
}
