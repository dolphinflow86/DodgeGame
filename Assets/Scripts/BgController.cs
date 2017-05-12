using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour {

    private Vector2 sprite_size;

    void Start ()
    {
        ResizeSpriteToScreen();
    }
	
	void Update ()
    {
		
	}

    void ResizeSpriteToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            return;
        }

        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector2 newScale = transform.localScale;
        newScale.x = worldScreenWidth / width;
        newScale.y = worldScreenHeight / height;
        transform.localScale = newScale;
    }
}