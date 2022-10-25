using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
	ControllerCheck controllerCheck;
	SceneController sceneController;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameManager = GameObject.Find("GameManager");
		controllerCheck = GetComponent<ControllerCheck>();

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();
	}

	// Update is called once per frame
	void Update()
	{

		if (controllerCheck)
		{
			if (Input.GetButtonDown("buttonX"))
			{
				//シーン切り替え
				sceneController.sceneChange("ProtoScene");
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				//シーン切り替え
				sceneController.sceneChange("ProtoScene");
			}
		}
	}
}
