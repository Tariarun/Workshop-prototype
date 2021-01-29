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
    [SerializeField] public Sprite[] icon;
    [SerializeField] public string[] turretName, description;

    [SerializeField] public GameObject[] uiPanels;

    [SerializeField] public GameObject[] ui;
    [SerializeField] public Button[] upgrade01, upgrade02, destroy, exit;

    public static GameplayManager Instance;
    public bool selectUiActivated = false;
    public Vector3 gmSpawnposition;
    public Vector3Int gmTilePosition;

    private float _chrono;
    
    public bool GamePaused
    {
        get; set;
    }
    public bool pause;

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
        GamePaused = false;
    }


    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            GamePaused = true;
            uiPanels[0].SetActive(true);
            uiPanels[2].SetActive(true);
        }

        if (seedsbox == null || seedsbox.Length == 0)
        {
            GamePaused = true;
            uiPanels[0].SetActive(true);
            uiPanels[1].SetActive(true);
        }
        
        if (pause == true)
        {
            GamePaused = true;
        }

        if (pause == false)
        {
            GamePaused = false;
        }

        if (GamePaused) { return; }
        _chrono += Time.deltaTime;
    }
}
