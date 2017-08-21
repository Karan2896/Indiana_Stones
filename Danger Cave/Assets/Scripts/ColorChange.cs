using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	SpriteRenderer sp;
	public float timer = 1f;
	bool red,white;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();	
		white = false;
		red = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			if (red == true) {
				
				sp.color = new Color(255,0,0,255); 
				red = false;
				white = true;
				timer = 1f;
			}
			else if (white == true) {
				
				sp.color = new Color (255,255,255,255);
				red = true;
				white = false;
				timer = 1f;
			}

		}


	}


}
