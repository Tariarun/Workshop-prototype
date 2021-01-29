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

    int ID;

    //public GameObject turretUi;
    //protected Button upgrade01, upgrade02, destroy, close;

    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = -Vector3.one;
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int tilePosition = maptilemap.WorldToCell(clickPosition);
            Vector3 spawnPosition = maptilemap.GetCellCenterWorld(tilePosition);

            //Les lignes ci-dessous permettent d'envoyer les valeurs à "PlacingUi" en passant par le Gameplay Manager
            GameplayManager.Instance.gmTilePosition = tilePosition;
            GameplayManager.Instance.gmSpawnposition = spawnPosition;

            if (Pathfinder.TileNode[tilePosition].usable)
            {
                selectUi.SetActive(true);
                GameplayManager.Instance.selectUiActivated = true;

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
                Destroy(Pathfinder.TileNode[tilePosition].objecton);
                Pathfinder.TileNode[tilePosition].objecton = Instantiate(GameplayManager.Instance.upgrades[1], newPosition, Quaternion.identity);

                GameplayManager.Instance.upgrade01[0] = Instantiate(GameplayManager.Instance.ui[0], FindObjectOfType<Canvas>().transform).GetComponent<Button>();
            }
            
        }
    }
}
