using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    

	void Start () {
        
        Cursor.visible = false;
        
    }

    
    void Update () {

        Vector2 newPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        
        transform.position = new Vector2(newPosition.x, newPosition.y);
        
        

     
    }
}
