using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage04Camera : MonoBehaviour
{
	GameObject obj;
	// Start is called before the first frame update
	void Start()
	{
		obj = GameObject.Find("TargetObj");
	}

	// Update is called once per frame
	void Update()
	{
		var pos = transform.position;
		pos.x = obj.transform.position.x;
		transform.position = pos;
	}
}
