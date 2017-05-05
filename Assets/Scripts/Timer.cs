using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Text text;
    GameController gc;

	void Start () {
        text = GetComponent<Text>();
        gc = FindObjectOfType<GameController>();

    }
	
	
	void Update () {
        text.text = gc.GetTime().ToString("f1");

	}
}
