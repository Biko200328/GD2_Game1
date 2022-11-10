using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager05 : MonoBehaviour
{
	public GameObject destroyObj1;
	public GameObject destroyObj2;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1920, 1080, false);
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void SwitchOn(GameObject obj)
	{
		if(obj.name == "pressure")Destroy(destroyObj1);
		else Destroy(destroyObj2);
	}
}
