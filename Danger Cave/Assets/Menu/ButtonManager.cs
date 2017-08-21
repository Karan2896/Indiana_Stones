using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {


	public GameObject Play;
	public GameObject Controls;
	public GameObject Exit;
	public GameObject ControlText;
	public GameObject Back;
	public AudioSource bgmusic;
	// Use this for initialization

	void Start()
	{
		bgmusic.Play ();
	}


	public void LoadGame()
	{
		SceneManager.LoadScene("Main");
	}
		
	public void LoadExit()
	{Application.Quit ();
	}

	public void SetControlsOn()
	{
		Play.SetActive (false);
		Controls.SetActive (false);
		Exit.SetActive (false);
		ControlText.SetActive (true);
		Back.SetActive (true);
	}
	public void SetControlsOff()
	{
		Play.SetActive (true);
		Controls.SetActive (true);
		Exit.SetActive (true);
		ControlText.SetActive (false);
		Back.SetActive (false);
	}

}
