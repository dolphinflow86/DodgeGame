using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {

    FloatingText popupText;
    GameObject canvas;

    public static FloatingTextController instance;

    private void Awake()
    {
        instance = this;
        canvas = FindObjectOfType<Canvas>().gameObject;
        popupText = Resources.Load<FloatingText>("Prefabs/PopupText_Parent");
    }

    public void CreateFloatingText(string text, Transform location)
    {
        FloatingText fText = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);        
        fText.transform.SetParent(canvas.transform, false);
        fText.transform.position = screenPosition;
        fText.SetText(text);
    }


}
