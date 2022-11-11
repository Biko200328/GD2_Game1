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

	public bool isClear;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		GameObject managerObj = GameObject.Find("StageManager");
		controllerCheck = managerObj.GetComponent<ControllerCheck>();

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();

		isDead = false;
		isClear = false;
	}

	void Update()
	{
		if(isClear == false)
		{
			if (controllerCheck.isConnection == false)
			{
				inputHorizontal = Input.GetAxisRaw("Horizontal");
				inputVertical = Input.GetAxisRaw("Vertical");
				if (Input.GetKey(KeyCode.Space))
				{
					ballRb.drag = dragPower;
				}
				else
				{
					ballRb.drag = 0;
				}
			}
			else
			{
				inputHorizontal = Input.GetAxis("cHorizontalL");
				inputVertical = Input.GetAxis("cVerticalL");
				if (Input.GetButton("buttonA"))
				{
					ballRb.drag = dragPower;
				}
				else
				{
					ballRb.drag = 0;
				}
			}

			if (this.transform.position.y <= deadY && !isDead)
			{
				isDead = true;
				string activeSceneName = SceneManager.GetActiveScene().name;
				sceneController.sceneChange(activeSceneName);
			}
		}
		else
		{
			if (controllerCheck.isConnection == false)
			{
				if (Input.GetKey(KeyCode.Space))
				{
					sceneController.sceneChange("StageSelect");
				}
			}
			else
			{
				if (Input.GetButton("buttonA"))
				{
					sceneController.sceneChange("StageSelect");
				}
			}
		}
		
	}

	void FixedUpdate()
	{
		if (isClear == false)
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
}
