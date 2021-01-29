using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    
    public GameObject[] seedsbox;

    [SerializeField] public float[] ratefire;
    [SerializeField] public int[] damage;
    [SerializeField] public int[] cost;
    [SerializeField] public int[] firerange;
    [SerializeField] public GameObject[] upgrades;
    [SerializeField] public Image[] icon;
    [SerializeField] public string[] turretName, description;

    [SerializeField] public GameObject[] ui;
    [SerializeField] public Button[] upgrade01, upgrade02, destroy, exit;

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
