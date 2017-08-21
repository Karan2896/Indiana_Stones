using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	int hitCount;
	ParticleSystem p;
	Animator anim;
	public static bool deadcheck;


	// Use this for initialization
	void Start () {
		hitCount = 0;
		deadcheck = false;
		p = GetComponent<ParticleSystem> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other )
	{
		if (other.gameObject.tag == "pickaxe") {
			hitCount++;
			p.Play ();

			if (hitCount == 3) {
				
				StartCoroutine (Drop ());
			}
		}
	}



	IEnumerator Drop()
	{
		
		anim.SetBool ("Dead", true);
		GameObject.FindGameObjectWithTag ("audio").GetComponent<audioManager> ().monsterdead.Play ();
		yield return new WaitForSeconds (1.2f);
		deadcheck = true;
		Destroy (gameObject);

	}
}
