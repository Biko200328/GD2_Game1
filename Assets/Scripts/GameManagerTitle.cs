using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTitle : MonoBehaviour
{
	ControllerCheck controllerCheck;
	SceneController sceneController;

	public AudioSource select;
	
	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1920, 1080, true);
		Application.targetFrameRate = 60;

		controllerCheck = GetComponent<ControllerCheck>();

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();
	}

	// Update is called once per frame
	void Update()
	{
		if(controllerCheck == false)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				select.Play();
				//シーン切り替え
				sceneController.sceneChange("StageSelect");
			}
		}
		else
		{
			if (Input.GetButtonDown("buttonA"))
			{
				select.Play();
				//シーン切り替え
				sceneController.sceneChange("StageSelect");
			}
		}
	}
}
