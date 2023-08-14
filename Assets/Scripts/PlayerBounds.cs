using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;
    public GameObject boundery;
    void Start()
    {
        mainCamera = Camera.main;

        playerWidth = boundery.GetComponent<MeshRenderer>().bounds.extents.x;
        playerHeight = boundery.GetComponent<MeshRenderer>().bounds.extents.y;

        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        transform.position = viewPos;
    }
}