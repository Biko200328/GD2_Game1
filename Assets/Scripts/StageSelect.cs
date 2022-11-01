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
				//�V�[���؂�ւ�
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
						//�V�[���؂�ւ�
						sceneController.sceneChange("ProtoScene");
						break;
					case 1:
						//�V�[���؂�ւ�
						
						break;
					case 2:
						//�V�[���؂�ւ�

						break;
					case 3:
						//�V�[���؂�ւ�

						break;
					case 4:
						//�V�[���؂�ւ�

						break;
					case 5:
						//�V�[���؂�ւ�

						break;
					case 6:
						//�V�[���؂�ւ�

						break;
				}
				
			}
		}
	}
}
