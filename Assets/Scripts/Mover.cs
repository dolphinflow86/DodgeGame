using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	void Start ()
    {
        Cursor.visible = false;
    }


    void Update ()
    {
        Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 mousePos = Input.mousePosition;
        //Debug.Log("mousePos : " + mousePos);
        Debug.Log("Bounds : " + sprite_size.x);
        //Debug.Log("ScreenX : " + Screen.width);
        //Debug.Log("ScreenY : " + Screen.height);

        // restrict the mouse position within screen
        mousePos.x = Mathf.Clamp(mousePos.x, 0.0f + (sprite_size.x * 0.5f), Screen.width - (sprite_size.x * 0.5f));
        mousePos.y = Mathf.Clamp(mousePos.y, 0.0f, Screen.height);

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector2(newPosition.x, newPosition.y);
    }
}
