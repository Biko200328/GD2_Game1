using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSphere : MonoBehaviour
{
	StageSelect stageSelect;

	// Start is called before the first frame update
	void Start()
	{
		GameObject selectObj = GameObject.Find("StageSelect");
		stageSelect = selectObj.GetComponent<StageSelect>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 potision = transform.position;

		switch (stageSelect.isStage)
		{
			case 0:
				potision.x = -7.8f;
				potision.y = 2.0f;
				break;
			case 1:
				potision.x = -1.8f;
				potision.y = 2.0f;
				break;
			case 2:
				potision.x = 4.2f;
				potision.y = 2.0f;
				break;
			case 3:
				potision.x = -7.8f;
				potision.y = -2.87f;
				break;
			case 4:
				potision.x = -1.8f;
				potision.y = -2.87f;
				break;
			case 5:
				potision.x = 4.2f;
				potision.y = -2.87f;
				break;
		}

		transform.position = potision;

	}
}
