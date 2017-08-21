using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRocks : MonoBehaviour {

	MeshRenderer sm;

	void Awake()
	{
		sm = GetComponentInChildren<MeshRenderer> (); 
		sm.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			sm.enabled = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		
		sm.enabled = false;

	}
}
