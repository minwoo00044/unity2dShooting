using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraitBullet : MonoBehaviour
{

    public GameObject player;
    public PlayerMove playerMove;
    public Camera mainCamera;

    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;


    private void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMove>();
        //transform.position = player.transform.position;

        if (transform.position.x > 0)
        {
            dir = Vector3.down;
        }


    }
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.Self);
        //transform.position += dir * speed * Time.deltaTime;
    }
}
