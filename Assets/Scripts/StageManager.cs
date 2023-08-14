using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] enemySpots;
    public GameObject[] enemyPrefab;


    public Camera mainCamera; // Ä«¸Þ¶ó



    public float[] stageMoveDuration;
    public float[] targetToDistanceX;
    public float[] targetToDistanceY;
    public float[] stageSpeeds;

    public float[] waitDuration;
    public int stageCount = 0;

    public GameObject topPosi;
    void Start()
    {
        enemySpots = GameObject.FindGameObjectsWithTag("EnemySpot");
        StartCoroutine(Stage1());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Stage1()
    {
        StartCoroutine(FirstWave(enemyPrefab[stageCount],stageMoveDuration[stageCount], targetToDistanceX[stageCount], targetToDistanceY[stageCount], stageSpeeds[stageCount]));
        yield return null;
    }

    IEnumerator FirstWave(GameObject prefab, float duration, float disX, float distY, float stageSpeed)
        
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < enemySpots.Length; i++)
        {
            GameObject currentEnemy = Instantiate(prefab);
            currentEnemy.transform.position = enemySpots[i].transform.position;
            MovementController movementController = currentEnemy.GetComponent<MovementController>();
            if(enemySpots[i].GetComponent<EnemySpawn>().isLeft)
            {
                Vector3 firstTarget = new Vector3(currentEnemy.transform.position.x + disX, currentEnemy.transform.position.y + distY, 0);
                movementController.MoveAtoBWithFire(firstTarget, duration, enemySpots[i].transform.position, stageSpeed);
            }
            else
            {
                Vector3 firstTarget = new Vector3(currentEnemy.transform.position.x + (disX * -1), currentEnemy.transform.position.y + distY, 0);
                movementController.MoveAtoBWithFire(firstTarget, duration, enemySpots[i].transform.position, stageSpeed);
            }

            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(waitDuration[stageCount]);
        stageCount++;
        StartCoroutine(SecondWave(enemyPrefab[stageCount], stageMoveDuration[stageCount], targetToDistanceX[stageCount], targetToDistanceY[stageCount], stageSpeeds[stageCount]));
        yield return null;
        
    }

    IEnumerator SecondWave(GameObject prefab, float duration, float disX, float distY, float stageSpeed)
    {
        for (int i = 0; i < enemySpots.Length; i++)
        {
            GameObject currentEnemy = Instantiate(prefab);
            currentEnemy.transform.position = enemySpots[i].transform.position;
            MovementController movementController = currentEnemy.GetComponent<MovementController>();
            if (enemySpots[i].GetComponent<EnemySpawn>().isLeft)
            {
                Vector3 firstTarget = new Vector3(currentEnemy.transform.position.x + disX, currentEnemy.transform.position.y + distY, 0);
                movementController.MoveAtoBWithFire(firstTarget, duration, enemySpots[i].transform.position, stageSpeed);
            }
            else
            {
                Vector3 firstTarget = new Vector3(currentEnemy.transform.position.x + (disX * -1), currentEnemy.transform.position.y + distY, 0);
                movementController.MoveAtoBWithFire(firstTarget, duration, enemySpots[i].transform.position, stageSpeed);
            }

            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(waitDuration[stageCount]);
        stageCount++;
        StartCoroutine(ThirdWave(enemyPrefab[stageCount], stageMoveDuration[stageCount], targetToDistanceX[stageCount], targetToDistanceY[stageCount], stageSpeeds[stageCount]));
        

        
    }

    IEnumerator ThirdWave(GameObject prefab, float duration, float disX, float distY, float stageSpeed)
    {
        for (int i = 0; i < enemySpots.Length - 2; i++)
        {
            GameObject currentEnemy = Instantiate(prefab);
            currentEnemy.transform.position = enemySpots[i].transform.position;
            MovementController movementController = currentEnemy.GetComponent<MovementController>();
            if (enemySpots[i].GetComponent<EnemySpawn>().isLeft)
            {
                Vector3 firstTarget = new Vector3(currentEnemy.transform.position.x + disX, currentEnemy.transform.position.y + distY, 0);
                movementController.MoveAtoBWithFire(firstTarget, duration, enemySpots[i].transform.position, stageSpeed);
            }
            else
            {
                Vector3 firstTarget = new Vector3(currentEnemy.transform.position.x + (disX * -1), currentEnemy.transform.position.y + distY, 0);
                movementController.MoveAtoBWithFire(firstTarget, duration, enemySpots[i].transform.position, stageSpeed);
            }

            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(waitDuration[stageCount]);
        stageCount++;
        StartCoroutine(FoutthWave(enemyPrefab[stageCount], stageMoveDuration[stageCount], targetToDistanceX[stageCount], targetToDistanceY[stageCount], stageSpeeds[stageCount]));

    }

    IEnumerator FoutthWave(GameObject prefab, float duration, float disX, float distY, float stageSpeed)
    {
        GameObject currentEnemy =  Instantiate(prefab);
        currentEnemy.transform.position = topPosi.transform.position;
        MovementController movementController = currentEnemy.GetComponent<MovementController>();
        Vector3 firstTarget = new Vector3(currentEnemy.transform.position.x + disX, currentEnemy.transform.position.y + distY, 0);
        movementController.MoveAtoBWithFire(firstTarget, duration, topPosi.transform.position, stageSpeed);

        GameObject currentEnemy1 = Instantiate(prefab);
        currentEnemy1.transform.position = topPosi.transform.position;
        MovementController movementController1 = currentEnemy1.GetComponent<MovementController>();
        Vector3 firstTarget1 = new Vector3(currentEnemy1.transform.position.x - disX, currentEnemy1.transform.position.y + distY, 0);
        movementController1.MoveAtoBWithFire(firstTarget1, duration, topPosi.transform.position, stageSpeed);


        yield return null;
    }
}
