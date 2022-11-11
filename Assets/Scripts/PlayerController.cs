using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	//���܁[�Ƀ{�[���̏�ɏ��o�O������

	//�v���C���[�̈ړ��X�s�[�h
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
			// �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
			Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

			// �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
			Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

			// �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂��B
			rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

			// �L�����N�^�[�̌�����i�s������
			if (moveForward != Vector3.zero)
			{
				transform.rotation = Quaternion.LookRotation(moveForward);
			}
		}
		
	}
}
