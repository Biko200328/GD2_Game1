using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	GameObject targetObj;
	Vector3 targetPos;

	GameManager gameManager;

	void Start()
	{
		targetObj = GameObject.Find("TargetObj");
		targetPos = targetObj.transform.position;

		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
	}

	void Update()
	{
		// targetの移動量分、自分（カメラ）も移動する
		transform.position += targetObj.transform.position - targetPos;
		targetPos = targetObj.transform.position;

		float inputX = 0f, inputY = 0f,power = 0f;

		if(gameManager.isConnection == false)
		{
			power = 200f;
			// マウスの左クリックを押している間
			if (Input.GetMouseButton(0))
			{
				// マウスの移動量
				inputX = Input.GetAxis("Mouse X");
				inputY = Input.GetAxis("Mouse Y");
			}
		}
		else
		{
			power = 100f;
			inputX = Input.GetAxis("cHorizontalR");
			inputY = Input.GetAxis("cVerticalR");
		}

		// targetの位置のY軸を中心に、回転（公転）する
		transform.RotateAround(targetPos, Vector3.up, inputX * Time.deltaTime * power);
		// カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
		transform.RotateAround(targetPos, transform.right, -inputY * Time.deltaTime * power);
	}
}
