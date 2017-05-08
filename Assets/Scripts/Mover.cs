using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Vector2 sprite_size;
    Vector2 local_size;

    void Start()
    {
        Cursor.visible = false;
        sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
        local_size = gameObject.transform.localScale;
    }

    void Update ()
    {
        
        Vector2 mousePos = Input.mousePosition;
        //Debug.Log("mousePos : " + mousePos);
        //Debug.Log("Bounds : " + sprite_size.x);
        //Debug.Log("ScreenX : " + Screen.width);
        //Debug.Log("ScreenY : " + Screen.height);

        // restrict the mouse position within screen
        mousePos.x = Mathf.Clamp(mousePos.x, 0.0f + (sprite_size.x * 0.3f * local_size.x), Screen.width - (sprite_size.x * 0.3f * local_size.x));
        mousePos.y = Mathf.Clamp(mousePos.y, (sprite_size.y * 0.3f * local_size.y), Screen.height - (sprite_size.y * 0.3f * local_size.y));

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector2(newPosition.x, newPosition.y);
    }
}
