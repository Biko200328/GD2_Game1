using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetMove : MonoBehaviour
{
	GameObject player;
	GameObject ball;
	void Start()
	{
		player = GameObject.Find("Player");
		ball = GameObject.Find("Ball");
	}

	void Update()
	{
		var a = player.transform.position - ball.transform.position;
		transform.position = player.transform.position - a / 2;
		//this.transform.position = obj.transform.position;
	}
}
