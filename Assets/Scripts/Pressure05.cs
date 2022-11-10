using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure05 : MonoBehaviour
{
	StageManager05 stageManager;

	// Start is called before the first frame update
	void Start()
	{
		GameObject managerObj = GameObject.Find("StageManager");
		stageManager = managerObj.GetComponent<StageManager05>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			stageManager.SwitchOn(this.gameObject);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			stageManager.SwitchOn(this.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			stageManager.SwitchOn(this.gameObject);
		}
	}
}
