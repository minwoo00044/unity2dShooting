using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// ��ǥ : ����� �Է�(Space)�� �޾� �Ѿ��� ����� �ʹ�.
//1. �Է¹ް�
//2. �Ѿ˻���

//��ǥ2 : �������� �Ծ��ٸ�, ��ų ������ �ö󰣴�.
//�Ӽ� : ��ų����
//������Ʈ Ǯ��
//�ʿ� : �Ҹ� ������Ʈ ����, Ǯ �迭
//1. Ǯ ������ ��ŭ �迭 ����
//2. �Ҹ� ���� ������Ʈ�� �����Ѵ�.
//3. ������ ���� ������Ʈ�� Ǯ�� �ִ´�.
public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunPos;
    public int skillLevel = 0;

    public AudioClip fireSound;
    // Update is called once per frame

    public int poolSize = 100;
    //GameObject[] bulletObjectPool;
    public List<GameObject> bulletObjectPool;

    public Transform gun;

    private void Start()
    {
        //bulletObjectPool = new GameObject[poolSize];
        bulletObjectPool = new List<GameObject> ();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(bullet);
            instance.SetActive(false);
            instance.transform.parent = gun;
            bulletObjectPool.Add(instance);
        }
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (skillLevel > 3)
                skillLevel = 3;
            // 2. �Ѿ� �����
            SoundManager.Instance.PlaySound(fireSound, 0.3f);
            ExcuteSkill();
        }
#elif UNITY_ANDROID
#endif
        //1. �Է� �ޱ�

    }

    public void ExcuteSkill()
    {
        switch (skillLevel)
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
            //for(int i = 0; i < poolSize; i++)
            //{
            //    GameObject instace = bulletObjectPool[i];
            //    if (!instace.activeSelf)
            //    {
            //        instace.SetActive(true);
            //        instace.transform.position = gunPos.transform.position;
            //        break;
            //    }
            //}
            if(bulletObjectPool.Count > 0)
            {
                GameObject instance = bulletObjectPool[0];
                instance.transform.position = gunPos.transform.position;
                instance.SetActive(true);

                bulletObjectPool.Remove(instance);
            }

        }
        //�� ���� �Ѿ��� �߻�ȴ�.
        void ExcuteSkill_2()
        {

            if (bulletObjectPool.Count > 0)
            {
                GameObject instance = bulletObjectPool[0];
                instance.transform.position = gunPos.transform.position;
                instance.SetActive(true);

                bulletObjectPool.Remove(instance);
            }
            if (bulletObjectPool.Count > 0)
            {
                GameObject instance = bulletObjectPool[0];
                instance.transform.position = gunPos.transform.position;
                instance.SetActive(true);

                bulletObjectPool.Remove(instance);
            }
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
