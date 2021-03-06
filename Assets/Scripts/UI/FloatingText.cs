﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {

    Animator animator;
    Text damageText;

	void Awake ()
    {
        animator = GetComponentInChildren<Animator>();
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        damageText = animator.GetComponent<Text>();
	}
	
    public void SetText(string text)
    {        
        animator.GetComponent<Text>().text = text;
    }

}
