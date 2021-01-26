using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    /// AI Behaviour
    public enum BehaviourAI
    {
        Idle,
        Attacking,

    }
    public BehaviourAI ActualBehaviour = BehaviourAI.Idle;
    /// /AI Behaviour
    
    /// waypoints system
    private Stack<Vector3> waypoints;
    private Vector3 nextwaypoint;
    /// /waypoints system
    
    /// /abilities
    [SerializeField] private float reflex;
    [SerializeField] private float speed;
    [SerializeField] private int PointToStart;
    public int id;
    /// /abilities

    /// target
    protected Vector3 target;

    protected Vector3 lasttarget;
    /// /target
    
    /// pathfinder
    [SerializeField]
    public Pathfinder _pathfinder;
    /// /pathfinder

    public virtual void Start() //Settings the waypoints stack, get the pathfinder and StartCoroutine Loop
    {
        waypoints = new Stack<Vector3>();
        _pathfinder = GameObject.FindWithTag("GameplayManager").GetComponent<Pathfinder>();
        StartCoroutine(FindPath());
    }
    
    public virtual void Update() //used to navigate between each waypoint in the waypoints stack + manage the sprite color and behaviour if fear is true
    {

        if (waypoints.Count > 0)
        {
            if (transform.position != nextwaypoint && nextwaypoint != Vector3.zero)
            {
                this.GetComponent<Animator>().SetFloat("Yvector", nextwaypoint.y  - transform.position.y);
                this.GetComponent<Animator>().SetFloat("Xvector", nextwaypoint.x  - transform.position.x);
                transform.position = Vector3.MoveTowards(transform.position, nextwaypoint, speed * Time.deltaTime);
            }
            else
            {
                nextwaypoint = waypoints.Pop();
            }
        }




    }

    public virtual IEnumerator FindPath() //Coroutine that make the "reflex" of the AI in a switch. it calls pathfinder class when needed to find a path to the target and get the waypoints that it return
    {
        while (true)
        {
            switch (ActualBehaviour)
            {
                case BehaviourAI.Attacking:
                    Debug.Log("In Attack");
                    if (target != Vector3.zero)
                    {

                        waypoints = _pathfinder.Pathfind(transform.position, target);
                        Debug.Log("Target is "+target);
                    }
                    yield return new WaitForSeconds(reflex);
                    break;

                case BehaviourAI.Idle:
                    Debug.Log("In Idle");
                   
                    yield return new WaitForSeconds(reflex);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //used to detect when player collide with enemies
    {

        
    }
}
