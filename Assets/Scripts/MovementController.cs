using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class MovementController : MonoBehaviour
{
    private Vector3 firstTarget;
    private Vector3 secondTarget;
    private float speed;

    public GameObject bullet;
    public GameObject sinBullet;
    public GameObject straitBullet;

    public int poolSize = 30;
    public List<GameObject> bulletObjectPool;
    public List<GameObject> straitObjectPool;
    public List<GameObject> sinObjectPool;

    public int fIreCount;
    public bool isShoot;
    [Range(0, 3)]
    public int fIreType;

    public Camera mainCamera;

    public GameObject bullets;

    private void Start()
    {
        mainCamera = Camera.main;
        bullets = GameObject.FindWithTag("Container");
        bulletObjectPool = new List<GameObject>();
        straitObjectPool = new List<GameObject>();
        sinObjectPool = new List<GameObject>();


        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(bullet);
            instance.GetComponent<EnemyBullet_damage>().movementController = this;
            instance.SetActive(false);
            instance.transform.position = gameObject.transform.position;
            bulletObjectPool.Add(instance);
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(sinBullet);
            instance.SetActive(false);
            instance.transform.position = gameObject.transform.position;
            sinObjectPool.Add(instance);
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(straitBullet);
            instance.SetActive(false);
            instance.transform.position = gameObject.transform.position;
            straitObjectPool.Add(instance);
        }
    }
    private void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPos.x > 0 && viewportPos.x < 1 && viewportPos.y > 0 && viewportPos.y < 1 && viewportPos.z > 0)
        {
            isShoot = true;
        }
        else
        {
            isShoot = false;
        }
    }
    public void MoveAtoBWithFire(Vector3 target1, float stopTime, Vector3 target2, float moveSpeed)
    {
        firstTarget = target1;
        secondTarget = target2;
        speed = moveSpeed;

        float distanceToTarget1 = Vector3.Distance(transform.position, firstTarget);
        float arrivalTimeToTarget1 = distanceToTarget1 / speed;


        // Start moving towards the first target
        StartCoroutine(MoveToTarget(firstTarget, stopTime));

        switch (fIreType)
        {
            case 0:
                StartCoroutine(FireBulelt(arrivalTimeToTarget1 + stopTime));
                break;
            case 1:
                StartCoroutine(FireSinBullet(arrivalTimeToTarget1 + stopTime));
                break;
            case 2:
                StartCoroutine(Fire2WayBullet(arrivalTimeToTarget1 + stopTime));
                break;
            case 3:
                StartCoroutine(FireRoundBullet(arrivalTimeToTarget1 + stopTime));
                break;

        }


        // Wait for the specified stop time

    }

    private IEnumerator MoveToTarget(Vector3 target, float stopTime = 0)
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        if (stopTime != 0)
        {
            StartCoroutine(StopForDuration(stopTime));
        }
        else if (stopTime == 0)
        {
            gameObject.SetActive(false);
        }

    }
    private IEnumerator StopForDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Move to the second target after the stop duration
        StartCoroutine(MoveToTarget(secondTarget));
    }

    private IEnumerator FireBulelt(float fireTime)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < fIreCount; i++)
        {
            if (isShoot)
            {
                if (bulletObjectPool.Count > 0)
                {
                    GameObject instance = bulletObjectPool[0];
                    instance.transform.position = transform.position;
                    instance.SetActive(true);
                    bulletObjectPool.Remove(instance);
                }
                yield return new WaitForSeconds(fireTime / (float)fIreCount);
            }

        }
        yield return null;

    }

    private IEnumerator FireSinBullet(float fireTime)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < fIreCount; i++)
        {
            if (isShoot)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sinObjectPool.Count > 0)
                    {
                        GameObject instance = sinObjectPool[0];
                        instance.transform.position = transform.position;
                        instance.transform.rotation = Quaternion.Euler(0, 0, 20 * i);
                        instance.SetActive(true);
                        sinObjectPool.Remove(instance);
                    }

                }
                yield return new WaitForSeconds(fireTime / (float)fIreCount);
            }

        }
    }

    private IEnumerator Fire2WayBullet(float fireTime)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < fIreCount; i++)
        {
            if (isShoot)
            {
                for (int j = 0; j < poolSize; j++)
                {
                    if (straitObjectPool.Count > 0)
                    {
                        GameObject instance = straitObjectPool[0];
                        instance.transform.position = transform.position;
                        instance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30f));
                        instance.SetActive(true);
                        straitObjectPool.Remove(instance);

                        GameObject instance1 = straitObjectPool[0];
                        instance1.transform.position = transform.position;
                        instance1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -150f));
                        instance1.SetActive(true);
                        straitObjectPool.Remove(instance1);
                    }
                    yield return new WaitForSeconds(fireTime / ((float)fIreCount));
                }

            }

        }
    }

    private IEnumerator FireRoundBullet(float fireTime)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < fIreCount; i++)
        {
            if (isShoot)
            {
                for (int j = 1; j < 25; j++)
                {


                    if (straitObjectPool.Count > 0)
                    {
                        GameObject instance = straitObjectPool[0];
                        instance.transform.position = transform.position;
                        instance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 15f * j));
                        instance.SetActive(true);
                        straitObjectPool.Remove(instance);
                    }



                }
                yield return new WaitForSeconds(0.1f);

            }
            yield return new WaitForSeconds(fireTime / (float)fIreCount);
        }
    }
}
