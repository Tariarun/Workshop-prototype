using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Placing : MonoBehaviour
{
    public bool occupied = false;
    public Tilemap maptilemap;

    private Camera cam;
    public GameObject selectUi;
    private Vector3 spawnPosition;
    private Vector3Int tilePosition;

    private bool uiactive = false;
    int ID;
    [SerializeField] private GameObject[] Uibutton;
    [SerializeField] private Image[] Uiimage;

    //public GameObject turretUi;
    //protected Button upgrade01, upgrade02, destroy, close;

    void Start()
    {
        cam = Camera.main;
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !uiactive)
        {
            Vector3 clickPosition = -Vector3.one;
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            tilePosition = maptilemap.WorldToCell(clickPosition);
            spawnPosition = maptilemap.GetCellCenterWorld(tilePosition);

            if (Pathfinder.TileNode[tilePosition].usable)
            {

                ID = -1;
                
                selectUi.transform.position = spawnPosition;

                Uiimage[0].sprite = GameplayManager.Instance.icon[0];
                Uiimage[1].sprite = GameplayManager.Instance.icon[5];
                Uiimage[2].sprite = GameplayManager.Instance.icon[10];
                Uibutton[3].SetActive(false);
                selectUi.SetActive(true);
                uiactive = true;





                /*if (bouton 1 est cliqué)
                 * {
                 * ID = 0;
                 * Pathfinder.TileNode[tilePosition].objecton = Instantiate(GameplayManager.Instance.upgrades[ID], spawnPosition, Quaternion.identity);
                 * }
                 * 
                 * if (bouton 2 est cliqué)
                 * {
                 * ID = 5;
                 * Pathfinder.TileNode[tilePosition].objecton = Instantiate(GameplayManager.Instance.upgrades[ID], spawnPosition, Quaternion.identity);
                 * }
                 * 
                 * if (bouton 3 est cliqué)
                 * {
                 * ID = 10;
                 * Pathfinder.TileNode[tilePosition].objecton = Instantiate(GameplayManager.Instance.upgrades[ID], spawnPosition, Quaternion.identity);
                 * }
                */

                //Pathfinder.TileNode[tilePosition].objecton = Instantiate(GameplayManager.Instance.upgrades[0], spawnPosition, Quaternion.identity);
                //Pathfinder.TileNode[tilePosition].usable = false;

            }
            else
            {
                Vector3 newPosition = spawnPosition;
                ID = 1;
                Debug.Log("What is gameobjecton "+ Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID.Length);
                if (Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID.Length == 2)
                {
                    Uiimage[0].sprite = GameplayManager.Instance.icon[Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID[0]];
                    Uiimage[1].sprite = GameplayManager.Instance.icon[Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID[1]];
                    selectUi.SetActive(true);
                    Uibutton[0].SetActive(true);
                    Uibutton[1].SetActive(true);
                    Uibutton[2].SetActive(false);
                    Uibutton[3].SetActive(true);
                    uiactive = true;
                }else if (Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID.Length == 1)
                {
                    Uiimage[0].sprite = GameplayManager.Instance.icon[Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID[0]];

                    Uibutton[0].SetActive(true);
                    Uibutton[1].SetActive(false);
                    Uibutton[2].SetActive(false);
                    Uibutton[3].SetActive(true);
                    uiactive = true;
                }
                else
                {
                    Uibutton[0].SetActive(false);
                    Uibutton[1].SetActive(false);
                    Uibutton[2].SetActive(false);
                    Uibutton[3].SetActive(true);
                    uiactive = true;
                }
                
                
            }
            
        }
    }

    public void LeftUI()
    {
        if (ID == -1)
        {
            GameObject turret = Instantiate(GameplayManager.Instance.upgrades[0], spawnPosition, Quaternion.identity);
            Pathfinder.TileNode[tilePosition].objecton = turret;
            Pathfinder.TileNode[tilePosition].usable = false;
            selectUi.SetActive(false);
            uiactive = false;
        }
        else
        {
            GameObject turret = Instantiate(GameplayManager.Instance.upgrades[Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID[0]], spawnPosition, Quaternion.identity);
            Destroy(Pathfinder.TileNode[tilePosition].objecton);
            Pathfinder.TileNode[tilePosition].objecton = turret;
            Pathfinder.TileNode[tilePosition].usable = false;
            selectUi.SetActive(false);
            uiactive = false;
        }
    }
    
    public void UpUI()
    {
        if (ID == -1)
        {
            GameObject turret = Instantiate(GameplayManager.Instance.upgrades[5], spawnPosition, Quaternion.identity);
            Pathfinder.TileNode[tilePosition].objecton = turret;
            Pathfinder.TileNode[tilePosition].usable = false;
            selectUi.SetActive(false);
            uiactive = false;
        }
        else
        {
            GameObject turret = Instantiate(GameplayManager.Instance.upgrades[Pathfinder.TileNode[tilePosition].objecton.GetComponentInChildren<Turret>().upID[1]], spawnPosition, Quaternion.identity);
            Destroy(Pathfinder.TileNode[tilePosition].objecton);
            Pathfinder.TileNode[tilePosition].objecton = turret;
            Pathfinder.TileNode[tilePosition].usable = false;
            selectUi.SetActive(false);
            uiactive = false;
        }
    }
    
    public void RightUI()
    {
        if (ID == -1)
        {
            GameObject turret = Instantiate(GameplayManager.Instance.upgrades[10], spawnPosition, Quaternion.identity);
            Pathfinder.TileNode[tilePosition].objecton = turret;
            Pathfinder.TileNode[tilePosition].usable = false;
            selectUi.SetActive(false);
            uiactive = false;
        }
    }
    
    public void DownUI()
    {
        if (ID == -1)
        {
            Destroy(Pathfinder.TileNode[tilePosition].objecton);
            Pathfinder.TileNode[tilePosition].objecton = null;
            Pathfinder.TileNode[tilePosition].usable = true;
            selectUi.SetActive(false);
            uiactive = false;

        }
    }
    
}
