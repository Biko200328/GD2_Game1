using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	//たまーにボールの上に乗るバグがある

	//プレイヤーの移動スピード
	[SerializeField] private float speed;

	ControllerCheck controllerCheck;

	float inputHorizontal;
	float inputVertical;
	Rigidbody rb;

	[SerializeField] Rigidbody ballRb;
	[SerializeField] float dragPower;

	SceneController sceneController;
	[SerializeField] float deadY = -10f;
	bool isDead = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		GameObject managerObj = GameObject.Find("StageManager");
		controllerCheck = managerObj.GetComponent<ControllerCheck>();

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();

		isDead = false;
	}

	void Update()
	{
		if(controllerCheck.isConnection == false)
		{
			inputHorizontal = Input.GetAxisRaw("Horizontal");
			inputVertical = Input.GetAxisRaw("Vertical");
			if(Input.GetKey(KeyCode.Space))
			{
				ballRb.drag = dragPower;
			}
			else
			{
				ballRb.drag = 0f;
			}
		}
		else
		{
			inputHorizontal = Input.GetAxis("cHorizontalL");
			inputVertical = Input.GetAxis("cVerticalL");
			if(Input.GetButton("buttonX"))
			{
				ballRb.drag = dragPower;
			}
			else
			{
				ballRb.drag = 0f;
			}
		}

		if(this.transform.position.y <= deadY && !isDead)
		{
			isDead = true;
			string activeSceneName = SceneManager.GetActiveScene().name;
			sceneController.sceneChange(activeSceneName);
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
