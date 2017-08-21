using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSkeleton : MonoBehaviour {

	SkinnedMeshRenderer sm;

	void Awake()
	{
		sm = GetComponent<SkinnedMeshRenderer> (); 
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
