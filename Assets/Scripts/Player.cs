using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 movement;
    private Camera _camera;
    private Vector2 boundlimit;
    [SerializeField] private Vector2 playzone;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = correctmov(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        transform.Translate(movement.normalized * speed * Time.deltaTime);
    }



    private Vector2 correctmov(Vector2 move)
    {
        boundlimit = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        
        if (boundlimit.x >= playzone.x)
        {
            Debug.Log("X+ Corrected");
            move.x = Mathf.Clamp(move.x, -1f, 0f);
        }else if (boundlimit.x - playzone.x <= -playzone.x)
        {
            Debug.Log("X- Corrected");
            move.x = Mathf.Clamp(move.x, 0f, 1f);
        }

        if (boundlimit.y >= playzone.y)
        {
            Debug.Log("Y+ Corrected");
            move.y = Mathf.Clamp(move.y, -1f, 0f);
        }else if (boundlimit.y - playzone.y <= -playzone.y)
        {
            Debug.Log("Y- Corrected");
            move.y = Mathf.Clamp(move.y, 0f, 1f);
        }

        return move;
    }
}
