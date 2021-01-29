using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Placing : MonoBehaviour
{
    public bool occupied = false;
    public GameObject turret;
    public Tilemap maptilemap;

    //public GameObject turretUi;
    //protected Button upgrade01, upgrade02, destroy, close;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = -Vector3.one;
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int tilePosition = maptilemap.WorldToCell(clickPosition);
            Vector3 spawnPosition = maptilemap.GetCellCenterWorld(tilePosition);

            if (Pathfinder.TileNode[tilePosition].usable)
            {
                Pathfinder.TileNode[tilePosition].objecton = Instantiate(GameplayManager.Instance.upgrades[0], spawnPosition, Quaternion.identity);
                Pathfinder.TileNode[tilePosition].usable = false;
            }
            else
            {
                Vector3 newPosition = spawnPosition;
                Destroy(Pathfinder.TileNode[tilePosition].objecton);
                Pathfinder.TileNode[tilePosition].objecton = Instantiate(GameplayManager.Instance.upgrades[1], newPosition, Quaternion.identity);

                GameplayManager.Instance.upgrade01[0] = Instantiate(GameplayManager.Instance.ui[0], FindObjectOfType<Canvas>().transform).GetComponent<Button>();
            }
            
        }
    }
}
