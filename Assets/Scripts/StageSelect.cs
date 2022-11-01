using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
	ControllerCheck controllerCheck;
	SceneController sceneController;

	[SerializeField] int isStage = 0;

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
				if(isStage >= 6)
				{
					isStage = 6;
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
						sceneController.sceneChange("ProtoScene");
						break;
					case 1:
						//シーン切り替え
						
						break;
					case 2:
						//シーン切り替え

						break;
					case 3:
						//シーン切り替え

						break;
					case 4:
						//シーン切り替え

						break;
					case 5:
						//シーン切り替え

						break;
					case 6:
						//シーン切り替え

						break;
				}
				
			}
		}
	}
}
