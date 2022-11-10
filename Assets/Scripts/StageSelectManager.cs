using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
	ControllerCheck controllerCheck;

	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;

	// Start is called before the first frame update
	void Start()
	{
		controllerCheck = GetComponent<ControllerCheck>();
	}

	// Update is called once per frame
	void Update()
	{
		if(controllerCheck.isConnection == false)
		{
			text1.SetActive(true);
			text2.SetActive(true);
			text3.SetActive(false);
			text4.SetActive(false);
		}
		else
		{
			text1.SetActive(false);
			text2.SetActive(false);
			text3.SetActive(true);
			text4.SetActive(true);
		}
	}
}
