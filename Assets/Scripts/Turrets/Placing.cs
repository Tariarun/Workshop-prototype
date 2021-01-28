using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Placing : MonoBehaviour
{
    public bool occupied = false;
    public GameObject Turret;
    public Tilemap maptilemap;

    public Canvas CanvasObject;
    private bool isShowing;

    RectTransform turretui;
    private Vector2 uiOffset;

    public GameObject TurretCanon0Ui, TurretCanon1Ui, TurretCanon2Ui, TurretCanon3Ui, TurretCanon4Ui;
    public GameObject TurretGluegun0Ui, TurretGluegun1Ui, TurretGluegun2Ui, TurretGluegun3Ui, TurretGluegun4Ui;
    public GameObject TurretPlasmagun0Ui, TurretPlasmagun1Ui, TurretPlasmagun2Ui, TurretPlasmagun3Ui, TurretPlasmagun4Ui;
    public GameObject TurretSniper0Ui, TurretSniper1Ui, TurretSniper2Ui, TurretSniper3Ui, TurretSniper4Ui;

    void Start()
    {
        CanvasObject = GetComponent<Canvas>();
        RectTransform CanvasRect = GetComponent<RectTransform>();
        //this.uiOffset = new Vector2((float)Canvas.sizeDelta.x / 2f, (float)Canvas.sizeDelta.y / 2f);
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
                Pathfinder.TileNode[tilePosition].type = 10;
            }
            else
            {
                /* if (Pathfinder.TileNode[tilePosition].type == 10)
                 {
                     isShowing = !isShowing;
                     TurretCanon0Ui.SetActive(isShowing);
 
                     Vector2 ViewportPosition = Cam.WorldToViewportPointspawnposition);
                     Vector2 WorldObject_ScreenPosition = new Vector2(
                     ((ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
                     ((ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));
 
                     this.rectTransform.localPosition = proportionalPosition - uiOffset;
                 }*/
            }
            
        }
    }
}
