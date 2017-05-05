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
        //Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
        Vector2 mousePos = Input.mousePosition;
        //Debug.Log("mousePos : " + mousePos);
        //Debug.Log("Bounds : " + sprite_size);
        //Debug.Log("ScreenX : " + Screen.width);
        //Debug.Log("ScreenY : " + Screen.height);

        // restrict the mouse position within screen
        mousePos.x = Mathf.Clamp(mousePos.x, 10.0f, Screen.width - 10.0f);
        mousePos.y = Mathf.Clamp(mousePos.y, 10.0f, Screen.height - 10.0f);

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector2(newPosition.x, newPosition.y);
    }
}
