using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour {

	public Text score;
	public GameObject panel;
	float timer = 2f;
	int count;
	// Use this for initialization
	void Awake()
	{
		panel.SetActive (false);
	}

	void Start () {
		count = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerController.gameover == false) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				count++;
				score.text = "Score : " + count;
				timer = 2f;
			}
		} else {
				panel.SetActive(true);
			}
	}



	public void LoadGame()
	{
		SceneManager.LoadScene("Main");
	}
}
