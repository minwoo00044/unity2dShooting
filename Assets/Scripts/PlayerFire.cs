using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// 목표 : 사용자 입력(Space)를 받아 총알을 만들고 싶다.
//1. 입력받고
//2. 총알생성

//목표2 : 아이템을 먹었다면, 스킬 레벨이 올라간다.
//속성 : 스킬레벨
//오브젝트 풀링
//필요 : 불릿 오브젝트 개수, 풀 배열
//1. 풀 사이즈 만큼 배열 생성
//2. 불릿 게임 오브젝트를 생성한다.
//3. 생성한 게임 오브젝트를 풀에 넣는다.
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
            // 2. 총알 만들기
            SoundManager.Instance.PlaySound(fireSound, 0.3f);
            ExcuteSkill();
        }
#elif UNITY_ANDROID
#endif
        //1. 입력 받기

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
        //한 개의 총알이 발사 된다.
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
        //두 개의 총알이 발사된다.
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

            //회전 회오리

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
