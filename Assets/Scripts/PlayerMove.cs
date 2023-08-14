using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    public Camera mainCamera;

    public GameObject boundery;
    private float playerWidth;
    private float playerHeight;

    public GameObject hitFX;
    public AudioClip hitSound;
    [SerializeField]
    private int _hp;
    public int hp
    {
        get {return _hp;}
        set 
        { 
            GameObject instanceFX = Instantiate(hitFX);
            instanceFX.transform.position = transform.position;
            SoundManager.Instance.PlaySound(hitSound);
            _hp = value;
            if(_hp <= 0 )
            {
                GameManager.Instance.GameEnd();
            }
        }
    }

    void Start()
    {
        mainCamera = Camera.main;

        playerWidth = (boundery.GetComponent<MeshRenderer>().bounds.extents.x) * 2;
        playerHeight = (boundery.GetComponent<MeshRenderer>().bounds.extents.y) * 2;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.up * v;
        Vector3 newPos = transform.position + dir * speed * Time.deltaTime;

        // 플레이어가 카메라 밖으로 나가지 않도록 제한을 걸어줍니다.
        float distanceToCamera = Vector3.Distance(newPos, mainCamera.transform.position);
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera)).x - playerWidth;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, distanceToCamera)).y - playerHeight;
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).x + playerWidth;
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera)).y + playerHeight;

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        // 수정된 위치를 적용합니다.
        transform.position = newPos;

        // hp가 0 이하일 경우 게임 종료하고 플레이어를 제거하는 코드를 활성화시킬 수 있습니다.
        //if (hp <= 0)
        //{
        //    GameManager.Instance.GameEnd();
        //    Destroy(gameObject);
        //}
    }
}
