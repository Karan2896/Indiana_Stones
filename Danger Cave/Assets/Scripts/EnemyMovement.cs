using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	UnityEngine.AI.NavMeshAgent nav;
	Animator anim;
	bool isAttacking;
	playerController pc;

	void Awake()
	{
		isAttacking = false;
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Update()
	{
		if(isAttacking==false)
		nav.SetDestination (player.transform.position);
		else
			nav.SetDestination (transform.position);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			isAttacking = true;
			anim.SetBool ("Hit", true);
			StartCoroutine ("health");
		} else {
			isAttacking = false;
			anim.SetBool ("Hit", false);
		}
	}

	void OnCollisionExit(Collision other)
	{
		
			isAttacking = false;
			anim.SetBool ("Hit", false);

	}

	IEnumerator health()
	{
		yield return new WaitForSeconds (0.8f);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<playerController> ().Health -= 0.005f;
	}


}
