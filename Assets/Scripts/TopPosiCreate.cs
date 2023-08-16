using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������Ʈ Ǯ��
//�ʿ� : ���ʹ� ������Ʈ ����, Ǯ �迭
//1. Ǯ ������ ��ŭ �迭 ����
//2. ���ʹ� ���� ������Ʈ�� �����Ѵ�.
//3. ������ ���� ������Ʈ�� Ǯ�� �ִ´�.

//4. ������Ʈ Ǯ���� ���ʹ� ���ӿ�����Ʈ�� ��Ȱ��ȭ ���ִٸ� Ȱ��ȭ ��Ű�ڴ�.
public class TopPosiCreate : MonoBehaviour
{
    public GameObject enemy;
    public GameObject item;

    public float enemyDelay = 3f;
    public float itemDelay = 8f;

    public int poolSize = 10;
    public List<GameObject> enemyObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        enemyObjectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(enemy);
            instance.SetActive(false);
            instance.transform.parent = gameObject.transform;
            enemyObjectPool.Add(instance);
        }
        StartCoroutine(CreateEnemy());
        StartCoroutine(CreateItem());
    }

    IEnumerator CreateEnemy() 
    {
        yield return new WaitForSeconds(enemyDelay);
        int flag = Random.Range(-5, 5);
        if (enemyObjectPool.Count > 0)
        {
            GameObject instance = enemyObjectPool[0];
            instance.transform.parent = gameObject.transform;
            instance.transform.position = new Vector3(transform.position.x + flag, transform.position.y, 0);

            instance.SetActive(true);

            enemyObjectPool.Remove(instance);
        }
        //for (int i = 0; i < poolSize; i++)
        //{
        //    GameObject instacne = enemyObjectPool[i];
        //    if(!instacne.activeSelf)
        //    {
        //        instacne.SetActive(true);
        //        instacne.transform.position = new Vector3(transform.position.x + flag, transform.position.y, 0);
        //        break;
        //    }
        //}
        StartCoroutine(CreateEnemy());

    }

    IEnumerator CreateItem()
    {
        yield return new WaitForSeconds((itemDelay));
        int flag = Random.Range(-5, 5);
        GameObject instance = Instantiate(item);
        instance.transform.position = new Vector3(transform.position.x + flag, transform.position.y, 0);

        StartCoroutine(CreateItem());
    }
}
