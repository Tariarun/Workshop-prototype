﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject lasttarget;


    private int damage;
    int mask = 1 << 10 |  1 << 9;
    private GameObject[] ennemies;
    private GameObject target;
    [SerializeField] private GameObject bullet;
    private float bulletspeed = 20f;
    [SerializeField] private bool throughturret = false;

    private float angletotarget;
    private bool isfireok = true;
    public Transform bulletspawn;
    [SerializeField] private int ID;
    [SerializeField] public int[] upID;

    
    
    

    
    private Transform bulletcontainer;
    
    void Start()
    {
        bulletcontainer = GameObject.FindWithTag("bulletcontainer").transform;
        damage = GameplayManager.Instance.damage[ID];
        if (throughturret)
        {
            mask = 1 << 10;
        }




    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            LookTo(target);
            
            if (isfireok && IsFireLineClear(bulletspawn.position, target))
            {
                isfireok = false;
                Debug.Log("Before Fire couroutine");

                
                Shoot();
                

                StartCoroutine(Shootdelay(GameplayManager.Instance.ratefire[ID]));

                
            }

        }
        
    }

    private void FixedUpdate()
    {
        ennemies = GameObject.FindGameObjectsWithTag("Enemy");
        target = ClosestTarget(transform.position, ennemies);
    }

    private void Updgrade()
    {
        
    }
    
    private void LookTo(GameObject target)
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        angletotarget = angle -90;
    }

    private GameObject ClosestTarget(Vector3 position, GameObject[] targets)
    {
        
        if (targets == null || targets.Length == 0) return null;
        
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null)
            {
                lasttarget = targets[i];
                break;
            }
        }
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i] != null && Vector3.Distance(position, targets[i].transform.position) < Vector3.Distance(transform.position, lasttarget.transform.position))
            {
                lasttarget = targets[i];
                
            }
        }
        
        return lasttarget;
    }

    private bool IsFireLineClear(Vector3 position, GameObject target)
    {

        Debug.Log("Target at pos : "+target);
        Debug.Log("position"+ position);

        RaycastHit2D hit = Physics2D.Raycast(position, transform.right, GameplayManager.Instance.firerange[ID], mask);
        Debug.DrawLine(position, hit.point, Color.red, 1f);

        
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Debug.Log("Touching");
            Debug.DrawLine(position, hit.point, Color.red, 1f);
            return true;
        }
        else
        {
            Debug.Log("NotTouching");
            Debug.DrawRay(position, transform.up * 5000, Color.red);
            return false;
        }
    }
    
    public void Shoot()
    {
        GameObject thisbullet = Instantiate(bullet, bulletspawn.position, Quaternion.AngleAxis(angletotarget, Vector3.forward), bulletcontainer);
        thisbullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletspeed ;
        thisbullet.GetComponent<Bullet>().damage = damage;

    }

    IEnumerator Shootdelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        Debug.Log("FIRE");
        isfireok = true;
   
    }
}
