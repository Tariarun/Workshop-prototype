using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Placing : MonoBehaviour
{
    public bool occupied = false;
    public GameObject Turret;
    public Tilemap maptilemap;

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
                Pathfinder.TileNode[tilePosition].objecton = Instantiate(Turret, spawnPosition, Quaternion.identity);
                Pathfinder.TileNode[tilePosition].usable = false;
            }
            else
            {
                Debug.Log ("Impossible");
            }
            
        }
    }
}
