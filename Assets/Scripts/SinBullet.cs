using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinBullet : MonoBehaviour
{
    public Camera mainCamera;
    public float initialForce = 5f;
    public float upwardForce = 2f;

    void Start()
    {
        mainCamera = Camera.main;
        // Apply initial force in both x and y directions
        Rigidbody rb = GetComponent<Rigidbody>();
        if (transform.position.x > 0)
        {
            rb.AddForce(new Vector3((initialForce * -1), upwardForce * Random.Range(-3f,3f), 0), ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(new Vector3(initialForce, upwardForce * Random.Range(-3f, 3f), 0), ForceMode.Impulse);
        }

    }

    void Update()
    {
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
