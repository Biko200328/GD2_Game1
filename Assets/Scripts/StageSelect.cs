using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
	ControllerCheck controllerCheck;
	SceneController sceneController;

	public int isStage = 0;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameManager = GameObject.Find("GameManager");
		controllerCheck = GetComponent<ControllerCheck>();

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();

		isStage = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (controllerCheck)
		{
			if (Input.GetButtonDown("buttonA"))
			{
				//シーン切り替え
				sceneController.sceneChange("ProtoScene");
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				isStage++;
				if(isStage >= 5)
				{
					isStage = 5;
				}
			}
			else if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				isStage--;
				if (isStage <= 0)
				{
					isStage = 0;
				}
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				switch (isStage)
				{
					case 0:
						//シーン切り替え
						sceneController.sceneChange("Stage01");
						break;
					case 1:
						//シーン切り替え
						sceneController.sceneChange("Stage02");
						break;
					case 2:
						//シーン切り替え
						sceneController.sceneChange("Stage03");
						break;
					case 3:
						//シーン切り替え
						sceneController.sceneChange("Stage04");
						break;
					case 4:
						//シーン切り替え
						sceneController.sceneChange("Stage05");
						break;
					case 5:
						//シーン切り替え
						sceneController.sceneChange("Stage06");
						break;
				}
				
			}
		}
	}
}
