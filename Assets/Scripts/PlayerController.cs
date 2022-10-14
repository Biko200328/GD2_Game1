using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//�v���C���[�̈ړ��X�s�[�h
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
