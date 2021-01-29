
using UnityEngine;

public class Proto : Enemy
{
    public override void Start()
    {
        target = ClosestTarget(transform.position, GameplayManager.Instance.seedsbox);
        base.Start();
    }

    public override void Update() //Overriding the Update of Enemy class to change the target function
    {
        if (lasttarget == null) target = ClosestTarget(transform.position, GameplayManager.Instance.seedsbox);
        base.Update();
    }

    private GameObject ClosestTarget(Vector3 position, GameObject[] targets)
    {
        if (targets == null || targets.Length == 0) return this.gameObject;

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
}
