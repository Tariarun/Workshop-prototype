using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;
    [SerializeField]private bool slowpower;
    [SerializeField]private bool poisonpower;
    [SerializeField] private int poisondamage;
    [SerializeField]private bool shrapnelpower;
    private int shrapnelcounter = 0;
    [SerializeField]private bool penetratorpower;
    [SerializeField] private int slowtime;
    [SerializeField] private int shrapneldecrement;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Proto>().health -= damage;

            if (shrapnelpower)
            {
                if (shrapnelcounter > 2)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    other.GetComponent<Proto>().health -= damage;
                    shrapnelcounter++;
                }
            }
            else if (penetratorpower)
            {
                other.GetComponent<Proto>().health -= damage;
            }else
            {
                other.GetComponent<Proto>().health -= damage;
                Destroy(this.gameObject);
            }

        }
    }
}
