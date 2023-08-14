using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemOption
    {
        Point,
        LevelUP,
        heal
    }
    [SerializeField]
    private ItemOption type;
    public PlayerFire playerFire;
    public GameObject levelupFX;

    public AudioClip levelUpClip;
    public AudioClip pointClip;
    // Start is called before the first frame update
    void Start()
    {
        playerFire = GameObject.FindWithTag("Player").GetComponent<PlayerFire>();
        Destroy(gameObject, 8f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case ItemOption.Point:
                    GameManager.Instance.destroyScore += 10;
                    SoundManager.Instance.PlaySound(pointClip);
                    Destroy(gameObject);
                    break;
                case ItemOption.LevelUP:
                    GameManager.Instance.destroyScore += 20;
                    playerFire.skillLevel++;
                    GameObject instanceFX = Instantiate(levelupFX);
                    instanceFX.transform.position = playerFire.transform.position;
                    SoundManager.Instance.PlaySound(levelUpClip);
                    Destroy(gameObject);
                    break;
                case ItemOption.heal:
                    break;
            }
        }
    }
}
