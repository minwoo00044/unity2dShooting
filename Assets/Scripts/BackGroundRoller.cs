using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRoller : MonoBehaviour
{
    public float speed = 1.0f;
    float currentTime;
    public Material mat;
    public Camera mainCamera;
    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main;

        // Calculate the desired scale based on the orthographic size of the camera
        float orthographicSize = mainCamera.orthographicSize;
        float desiredScale = orthographicSize * 2.0f;

        // Apply the calculated scale to the object
        transform.localScale = new Vector3(desiredScale, desiredScale + 10, desiredScale);
    }

    private void Update()
    {
        currentTime += speed * Time.deltaTime;
        mat.mainTextureOffset = Vector3.up * currentTime;
    }
}
