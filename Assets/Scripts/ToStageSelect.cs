using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToStageSelect : MonoBehaviour
{
	public Text text;
	ControllerCheck controllerCheck;

	// Start is called before the first frame update
	void Start()
	{
		GameObject managerObj = GameObject.Find("StageManager");
		controllerCheck = managerObj.GetComponent<ControllerCheck>();
	}

	// Update is called once per frame
	void Update()
	{
		if (controllerCheck.isConnection) text.text = "Abutton�������ăX�e�[�W�Z���N�g��";
		else text.text = "Space�������ăX�e�[�W�Z���N�g��";
	}
}
