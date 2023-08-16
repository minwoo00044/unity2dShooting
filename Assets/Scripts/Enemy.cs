using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _hp;
    public GameObject pointItem;

    public GameObject destroyFX;
    public AudioClip deathClip;
    public int hp
    {
        get { return _hp; }
        set 
        { 
            _hp = value;
            if (_hp <= 0)
            {
                GameObject instanceItem =  Instantiate(pointItem);
                instanceItem.transform.position = transform.position;

                GameObject instanceDestroyFX = Instantiate(destroyFX);
                instanceDestroyFX.transform.position = transform.position;

                SoundManager.Instance.PlaySound(deathClip);
                gameObject.SetActive(false);
                if(gameObject.transform.parent != null && gameObject.transform.parent.name == "TopPosi")
                {
                    TopPosiCreate topPosiCreate = gameObject.transform.parent.GetComponent<TopPosiCreate>();
                    topPosiCreate.enemyObjectPool.Add(gameObject);
                }
            }
        }

    }
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
