using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Text text;
    

	void Start () {
        text = GetComponent<Text>();
       

    }
	
	
	void Update () {
        text.text = GameController.GetInstance().GetTime().ToString("f1");

	}
}
