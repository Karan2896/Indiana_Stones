using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Decrease : MonoBehaviour {
	[HideInInspector]
	public float current;
	public float decrease;
	public Slider slide;
	// Use this for initialization
	void Start () {
		current = 1.0f;	
	}

	
	// Update is called once per frame
	void Update () {
		decreaser ();	
	}
	void decreaser()
	{
		current = current - decrease;
		slide.value = current;
	}
}
