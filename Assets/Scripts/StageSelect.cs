using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
	ControllerCheck controllerCheck;
	SceneController sceneController;

	public int isStage = 0;

	public float inputHorizontal;
	public float oldInputHorizontal;

	public AudioSource button;
	public AudioSource select;

	// Start is called before the first frame update
	void Start()
	{
		GameObject gameManager = GameObject.Find("GameManager");
		controllerCheck = gameManager.GetComponent<ControllerCheck>();

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();

		isStage = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (controllerCheck.isConnection == true)
		{
			inputHorizontal = Input.GetAxisRaw("cHorizontalL");
			if(inputHorizontal > 0.5f)
			{
				inputHorizontal = 1;
			}
			else if(inputHorizontal > 0 && inputHorizontal <= 0.5f)
			{
				inputHorizontal = 0;
			}
			else if(inputHorizontal < 0 && inputHorizontal >= -0.5f)
			{
				inputHorizontal = 0;
			}
			else if(inputHorizontal < -0.5f)
			{
				inputHorizontal = -1;
			}

			if (inputHorizontal >= 1 && oldInputHorizontal <= 0)
			{
				isStage++;
				button.Play();
				if (isStage >= 4)
				{
					isStage = 4;
				}
			}
			else if (inputHorizontal <= -1 && oldInputHorizontal >= 0)
			{
				isStage--;
				button.Play();
				if (isStage <= 0)
				{
					isStage = 0;
				}
			}
			oldInputHorizontal = inputHorizontal;

			if (Input.GetButtonDown("buttonB"))
			{
				select.Play();
				sceneController.sceneChange("TitleScene");
			}

			if (Input.GetButtonDown("buttonA"))
			{
				select.Play();
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
						sceneController.sceneChange("Stage04");
						break;
					case 3:
						//シーン切り替え
						sceneController.sceneChange("Stage03");
						break;
					case 4:
						//シーン切り替え
						sceneController.sceneChange("Stage05");
						break;
				}

			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
			{
				isStage++;
				button.Play();
				if (isStage >= 4)
				{
					isStage = 4;
				}
			}
			else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
			{
				isStage--;
				button.Play();
				if (isStage <= 0)
				{
					isStage = 0;
				}
			}

			if(Input.GetKeyDown(KeyCode.Escape))
			{
				select.Play();
				sceneController.sceneChange("TitleScene");
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				select.Play();
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
						sceneController.sceneChange("Stage04");
						break;
					case 3:
						//シーン切り替え
						sceneController.sceneChange("Stage03");
						break;
					case 4:
						//シーン切り替え
						sceneController.sceneChange("Stage05");
						break;
				}
				
			}
		}
	}
}
