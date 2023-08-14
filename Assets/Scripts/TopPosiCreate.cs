using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPosiCreate : MonoBehaviour
{
    public GameObject enemy;
    public GameObject item;

    public float enemyDelay = 3f;
    public float itemDelay = 8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
        StartCoroutine(CreateItem());
    }

    IEnumerator CreateEnemy() 
    {
        yield return new WaitForSeconds(enemyDelay);
        int flag = Random.Range(-5, 5);
        GameObject instance = Instantiate(enemy);
        instance.transform.position = new Vector3(transform.position.x + flag, transform.position.y, 0);
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
