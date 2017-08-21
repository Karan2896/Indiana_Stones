using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	public float speed;
	Vector3 movement;
	Rigidbody playerRigidbody;
	int floormask;
	int camRaylength = 100;
	Animator anim;
	public GameObject Bone;
	Vector3 Offset = new Vector3(2,0,0);
	public float Health = 1f;
	private float Fire = 1f;
	public Slider h_slider;
	public Slider f_slider;
	float decrease;
	public Light lightt;
	public Camera cam;
	public LayerMask lm;
	public static bool gameover;
	public GameObject enemymanager;
	public audioManager am;
	public VirtualJoystick vj;


	void Awake()
	{
		Health = 1;
		Fire = 1f;
		gameover = false;
		decrease = 0.0004f;
		anim = GetComponent<Animator> ();
		floormask = LayerMask.GetMask ("Floor");
		playerRigidbody = GetComponent<Rigidbody> ();
		lightt.intensity = 8.31f;

	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			if (!am.sword.isPlaying)
				am.sword.Play ();
			anim.SetTrigger ("Slash");
		}

		if (anim.GetBool ("isWalking")) {
			if (Input.GetMouseButtonDown (0)) {
				anim.SetTrigger ("Slash");
				if (!am.sword.isPlaying)
					am.sword.Play ();
			}
		}

		decreaser ();
		fire_decreaser ();
	}

	void decreaser()
	{
		Health = Health - decrease;
		h_slider.value = Health;
		if (Fire < 0 || Health < 0) {
			Fire = 0;
			cam.cullingMask = lm;

			if (enemymanager.activeInHierarchy)
				enemymanager.SetActive (false);
			Health = 0;
			gameover = true;
			am.bgmusic.Stop ();
			am.gameObject.SetActive (false);
		}

	}

	void fire_decreaser()
	{
		Fire = Fire - 0.00048f;
		f_slider.value = Fire;
		lightt.intensity -= 0.0037f;
		if (Fire < 0 || Health < 0) {
			Fire = 0;
			cam.cullingMask = lm;
     
			if (enemymanager.activeInHierarchy)
				enemymanager.SetActive (false);
			Health = 0;
			gameover = true;
			am.bgmusic.Stop ();
			am.gameObject.SetActive (false);

		}
	}

	void FixedUpdate()
	{
		//float h = Input.GetAxis ("Horizontal");
		//float v = Input.GetAxis ("Vertical");

		float h = vj.Horizontal ();
		float v = vj.Vertical ();
		Debug.Log (h);
		Debug.Log (v);

		Move (h, v);
		Turning ();
		Animating (h, v);


	}

	void Move(float h,float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position+movement);

	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorhit;
		if(Physics.Raycast(camRay,out floorhit,camRaylength,floormask))
		{
			Vector3 playerToMouse = floorhit.point - transform.position;
			playerToMouse.y = 0;
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	}

	void Animating(float h,float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("isWalking", walking);

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Bone") {
			
			Destroy (other.gameObject);
			if(Health<=1)
				Health = 1f;
		}
		if (other.gameObject.tag == "Wood") {
			
			Destroy (other.gameObject);
			Fire = 1;

				lightt.intensity = 8.31f;
				/*if (lightt.intensity > 8.31f)
					lightt.intensity = 8.31f;*/
			}

		if (other.gameObject.tag == "Enemies" && Death.deadcheck==true) {
			int rdnm = Random.Range (0,15);
			if (rdnm > 11) {
				am.bone.Play ();
				Instantiate (Bone, other.transform.position + Offset, Quaternion.Euler (-90f, 0, 0));
			}
		}
	}
}
