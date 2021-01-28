using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private GameObject lasttarget;
    [SerializeField] private float ratefire;
    [SerializeField] private int damage;
    [SerializeField] private int cost;
    [SerializeField] private int firerange;
    [SerializeField] private GameObject[] upgrades;

    int mask = 1 << 10 |  1 << 9;
    private GameObject[] ennemies;
    private GameObject target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletspeed;
    private Animator _animator;
    private int isfireokanimhash;
    private float angletotarget;
    private bool isfireok = true;
    private Transform bulletspawn;
    
    

    
    private Transform bulletcontainer;
    
    void Start()
    {

        bulletspawn = transform.GetChild(1).GetComponent<Transform>();
        bulletcontainer = GameObject.FindWithTag("bulletcontainer").transform;
        _animator = this.GetComponentInChildren<Animator>();
        isfireokanimhash = Animator.StringToHash("SniperTurret1");


    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            LookTo(target);
            
            if (isfireok && IsFireLineClear(bulletspawn.position, target))
            {
                
                Debug.Log("Before Fire couroutine");
                _animator.Play(isfireokanimhash);
                StartCoroutine(Shootdelay(ratefire));
                isfireok = false;
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
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        angletotarget = angle;
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
        
        RaycastHit2D hit = Physics2D.Raycast(position, transform.right, firerange, mask);
        Debug.DrawLine(position, hit.point, Color.red, 1f);
        
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Debug.Log("Touching");
            return true;
        }
        else
        {
            Debug.Log("NotTouching");
            return false;
        }
    }
    
    public void Shoot()
    {
        GameObject thisbullet = Instantiate(bullet, bulletspawn.position, Quaternion.identity, bulletcontainer);
        thisbullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletspeed ;
        thisbullet.transform.rotation = Quaternion.AngleAxis(angletotarget-90, Vector3.forward);
    }

    IEnumerator Shootdelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        Debug.Log("FIRE");
        isfireok = true;
   
    }
}
