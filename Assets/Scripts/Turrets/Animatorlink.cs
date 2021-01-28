using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatorlink : MonoBehaviour
{
    private void shootcall()
    {
        if (GetComponentInParent<Turret>()) GetComponentInParent<Turret>().Shoot();


    }

}
