using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표 : 내가(총알) 위로 날아간다.
// 방향이 필요하다.
// 속도가 필요하다.

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;

    public GameObject bulletExplosion;
    public GameObject player;
    public Enemy enemy;
    public PlayerMove playerMove;
    public AudioClip clip;
    // 위로 날아가기

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMove>();
        //transform.position = player.transform.position;

        Destroy(gameObject, 2f);
    }
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.Self);
       //transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {

            GameObject bulletExplosion0 = Instantiate(bulletExplosion);
            bulletExplosion0.transform.position = transform.position;
            SoundManager.Instance.PlaySound(clip);

            enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.hp--;
            }



            Destroy(gameObject);
        }


    }

}
