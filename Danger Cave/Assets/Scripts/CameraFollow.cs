using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform Target;
	public float smoothing = 5f;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - Target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 targetcamPos = Target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetcamPos, smoothing * Time.deltaTime);
	}
}
