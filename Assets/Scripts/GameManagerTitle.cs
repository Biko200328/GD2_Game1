using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTitle : MonoBehaviour
{
	ControllerCheck controllerCheck;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1920, 1080, true);
		Application.targetFrameRate = 60;

		controllerCheck = GetComponent<ControllerCheck>();
	}

	// Update is called once per frame
	void Update()
	{
		if(controllerCheck)
		{
			if(Input.GetButtonDown("buttonX"))
			{
				//シーン切り替え

			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				//シーン切り替え

			}
		}
	}
}
