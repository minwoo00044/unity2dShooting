using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet_damage : MonoBehaviour
{

    public PlayerMove playerMove;
    public MovementController movementController;
    public GameObject bullets;

    private void OnEnable()
    {
        bullets = GameObject.FindWithTag("Container");
        StartCoroutine(returnPool());
    }
    private void Start()
    {
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if(movementController != null)
            {
                if (GetComponent<EnemysBullet>() != null)
                {
                    movementController.bulletObjectPool.Add(gameObject);
                }
                else if (GetComponent<SinBullet>() != null)
                {
                    movementController.sinObjectPool.Add(gameObject);
                }
                else if (GetComponent<StraitBullet>() != null)
                {
                    movementController.straitObjectPool.Add(gameObject);
                }
            }

            playerMove.hp -= 1;
            gameObject.SetActive(false);
        }
    }

    IEnumerator returnPool()
    {
        yield return new WaitForSeconds(7f);
        if (movementController != null)
        {
            if (GetComponent<EnemysBullet>() != null)
            {
                movementController.bulletObjectPool.Add(gameObject);
            }
            else if (GetComponent<SinBullet>() != null)
            {
                movementController.sinObjectPool.Add(gameObject);
            }
            else if (GetComponent<StraitBullet>() != null)
            {
                movementController.straitObjectPool.Add(gameObject);
            }
        }
        gameObject.SetActive(false);
    }
}
