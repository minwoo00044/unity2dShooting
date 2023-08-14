using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet_damage : MonoBehaviour
{

    public PlayerMove playerMove;

    private void Start()
    {
        playerMove = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        Destroy(gameObject, 7f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            playerMove.hp -= 1;
            Destroy(gameObject);
        }
    }
}
