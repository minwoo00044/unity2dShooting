using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Camera mainCamera;
    public bool isLeft;
    public float xOffset = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        float orthographicHalfHeight = mainCamera.orthographicSize;

        // Calculate the half-width of the camera's view based on the aspect ratio
        float orthographicHalfWidth = orthographicHalfHeight * mainCamera.aspect;

        


        if (isLeft)
        {
            orthographicHalfWidth = orthographicHalfWidth * -1;
            xOffset = xOffset * -1;
        }
        // Apply the calculated position to the object
        transform.position = new Vector3(orthographicHalfWidth/2 + xOffset, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
