using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysBullet : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 dir;
    public GameObject player;
    public Camera mainCamera;

    float dist;
    // 위로 날아가기
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        dir = (player.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.back, dir);
        transform.rotation = targetRotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

    }
}
