using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//プレイヤーの移動スピード
	[SerializeField] private float speed;

	GameManager gameManager;

	float inputHorizontal;
	float inputVertical;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		GameObject managerObj = GameObject.Find("GameManager");
		gameManager = managerObj.GetComponent<GameManager>();
	}

	void Update()
	{
		if(gameManager.isConnection == false)
		{
			inputHorizontal = Input.GetAxisRaw("Horizontal");
			inputVertical = Input.GetAxisRaw("Vertical");
		}
		else
		{
			inputHorizontal = Input.GetAxis("cHorizontalL");
			inputVertical = Input.GetAxis("cVerticalL");
		}
	}

	void FixedUpdate()
	{
		// カメラの方向から、X-Z平面の単位ベクトルを取得
		Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

		// 方向キーの入力値とカメラの向きから、移動方向を決定
		Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

		// 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
		rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

		// キャラクターの向きを進行方向に
		if (moveForward != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(moveForward);
		}
	}
}
