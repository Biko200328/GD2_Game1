using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMove : MonoBehaviour
{
	GameObject targetObj;
	Vector3 targetPos;

	ControllerCheck controllerCheck;

	// 前方の基準となるローカル空間ベクトル
	[SerializeField] private Vector3 _forward = Vector3.forward;

	PlayerController playerController;

	void Start()
	{
		targetObj = GameObject.Find("TargetObj");
		targetPos = targetObj.transform.position;

		GameObject managerObj = GameObject.Find("StageManager");
		controllerCheck = managerObj.GetComponent<ControllerCheck>();

		GameObject player = GameObject.Find("Player");
		playerController = player.GetComponent<PlayerController>();
	}

	void Update()
	{
		if(playerController.isClear == false)
		{
			// targetの移動量分、自分（カメラ）も移動する
			// そのまま動くとプレイヤーが見えなくなるのでとりあえず移動速度を1/2に
			transform.position += (targetObj.transform.position - targetPos) / 2;
			targetPos = targetObj.transform.position;

			float inputX = 0f, inputY = 0f, power = 0f;

			if (controllerCheck.isConnection == false)
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
				//コントローラー
				power = 100f;
				inputX = Input.GetAxis("cHorizontalR");
				inputY = Input.GetAxis("cVerticalR");
			}

			// targetの位置のY軸を中心に、回転（公転）する
			transform.RotateAround(targetPos, Vector3.up, inputX * Time.deltaTime * power);
			// カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
			transform.RotateAround(targetPos, transform.right, -inputY * Time.deltaTime * power);


			//注視点が動いた時に向きを自動で変えてあげる
			// ターゲットへの向きベクトル計算
			var dir = targetPos - this.transform.position;

			// ターゲットの方向への回転
			var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
			// 回転補正
			var offsetRotation = Quaternion.FromToRotation(_forward, Vector3.forward);

			// 回転補正→ターゲット方向への回転の順に、自身の向きを操作する
			this.transform.rotation = lookAtRotation * offsetRotation;
		}
	}
}
