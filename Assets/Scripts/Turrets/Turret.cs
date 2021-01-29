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
    [SerializeField] private string animname;

    int mask = 1 << 10 |  1 << 9;
    private GameObject[] ennemies;
    private GameObject target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletspeed;
    private Animator _animator;
    private int isfireokanimhash;
    private float angletotarget;
    private bool isfireok = true;
    public Transform bulletspawn;

    
    
    

    
    private Transform bulletcontainer;
    
    void Start()
    {
        bulletcontainer = GameObject.FindWithTag("bulletcontainer").transform;
        if (GetComponentInChildren<Animator>())
        {
            _animator = this.GetComponentInChildren<Animator>();
        }

        isfireokanimhash = Animator.StringToHash(animname);


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
                if (_animator != null)
                {
                    _animator.Play(isfireokanimhash); 
                }
                else
                {
                    Shoot();
                }

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
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(position, transform.up, firerange, mask))
        {
            Debug.Log("Collider name "+hit.collider.name);
        }
        
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

    }

    IEnumerator Shootdelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        Debug.Log("FIRE");
        isfireok = true;
   
    }
}
