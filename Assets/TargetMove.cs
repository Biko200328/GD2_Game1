using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetMove : MonoBehaviour
{
	GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
	}

	void Update()
	{
		this.transform.position = player.transform.position;
	}
}
