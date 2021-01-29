using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class seedbox : MonoBehaviour
{ 
    public int health = 100;
    private SpriteRenderer boxspriterenderer;
    [SerializeField] private Sprite[] boxsprites = new Sprite[3];
    [SerializeField] private GameObject destroyedbox;


    private void Start()
    {
        boxspriterenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Instantiate(destroyedbox, transform.position, quaternion.identity);
            Destroy(this.gameObject);   
        }

        if (health <= 100 && health > 70)
        {
            boxspriterenderer.sprite = boxsprites[2];
        }

        else if (health < 70 && health > 50)
        {
            boxspriterenderer.sprite = boxsprites[1];
        }
        else
        {
            boxspriterenderer.sprite = boxsprites[0];
        }
    }
}
