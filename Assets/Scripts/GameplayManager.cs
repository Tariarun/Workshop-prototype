using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    
    public GameObject[] seedsbox;
    
    public static GameplayManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        seedsbox = GameObject.FindGameObjectsWithTag("seedsbox");
    }


    void Update()
    {
        
    }
}
