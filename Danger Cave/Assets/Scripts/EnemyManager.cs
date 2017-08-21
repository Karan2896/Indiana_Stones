using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnpoints;
	public float spawnTime = 3f;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn",spawnTime,spawnTime);
	}

	void Spawn()
	{
		int SpawnPoinIndex = Random.Range (0,spawnpoints.Length);
		Instantiate (enemy, spawnpoints [SpawnPoinIndex].position, spawnpoints [SpawnPoinIndex].rotation);
	}

}
