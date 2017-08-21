using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWood : MonoBehaviour {

	public GameObject wood;
	private float timer;
	public GameObject[] points;
	// Use this for initialization
	void Start () {
		timer = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			int rnd = Random.Range (0, 24);
			Instantiate (wood, points [rnd].transform.position, Quaternion.Euler (-90f,0,0));
			rnd = Random.Range (0, 24);
			Instantiate (wood, points [rnd].transform.position, Quaternion.Euler (-90f,0,0));
			rnd = Random.Range (0, 24);
			Instantiate (wood, points [rnd].transform.position, Quaternion.Euler (-90f,0,0));
			timer = 2.5f;
		}
	}
}
