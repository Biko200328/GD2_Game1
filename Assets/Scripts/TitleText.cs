using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleText : MonoBehaviour
{
	ControllerCheck controllerCheck;
	[SerializeField]Text text;

	// Start is called before the first frame update
	void Start()
	{
		GameObject managerObj = GameObject.Find("GameManagerTitle");
		controllerCheck = managerObj.GetComponent<ControllerCheck>();
	}

	// Update is called once per frame
	void Update()
	{
		if(controllerCheck.isConnection)
		{
			text.text = "A to start";
		}
		else
		{
			text.text = "space to start";
		}
	}
}
