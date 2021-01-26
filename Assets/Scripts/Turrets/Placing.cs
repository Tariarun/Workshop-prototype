using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing : MonoBehaviour
{
    public bool occupied = false;
    public GameObject Turret;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = -Vector3.one;
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 0f)); 

            GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
            Vector3Int cellPosition = gridLayout.WorldToCell(transform.position);
            transform.position = gridLayout.CellToWorld(cellPosition);

            Instantiate(Turret, cellPosition, Quaternion.identity);
        }
    }

    //GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
    //Vector3Int cellPosition = gridLayout.WorldToCell(transform.position);
    //transform.position = gridLayout.CellToWorld(cellPosition);
}
