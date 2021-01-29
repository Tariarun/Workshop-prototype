using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlacingUi : MonoBehaviour
{
    public bool occupied = false;
    public Tilemap maptilemap;

    private Camera cam;
    [SerializeField] public Transform lookAt;
    [SerializeField] public GameObject lookedAt;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameplayManager.Instance.selectUiActivated == true)
        {
            Vector3 clickPosition = -Vector3.one;
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("début: " + transform.position);

            if (Pathfinder.TileNode[GameplayManager.Instance.gmTilePosition].usable)
            {
                Instantiate(lookedAt, GameplayManager.Instance.gmSpawnposition, Quaternion.identity);
                Vector3 selectUiPosition = cam.WorldToScreenPoint(lookAt.position);
                Debug.Log("milieu: " + transform.position);

                if (transform.position != selectUiPosition)
                {
                    transform.position = selectUiPosition;
                    Debug.Log("fin: " + transform.position);
                }
            }
        }
    }
}
