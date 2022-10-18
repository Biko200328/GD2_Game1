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
		// target�̈ړ��ʕ��A�����i�J�����j���ړ�����
		transform.position += targetObj.transform.position - targetPos;
		targetPos = targetObj.transform.position;

		float inputX = 0f, inputY = 0f,power = 0f;

		if(gameManager.isConnection == false)
		{
			power = 200f;
			// �}�E�X�̍��N���b�N�������Ă����
			if (Input.GetMouseButton(0))
			{
				// �}�E�X�̈ړ���
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

		// target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
		transform.RotateAround(targetPos, Vector3.up, inputX * Time.deltaTime * power);
		// �J�����̐����ړ��i���p�x�����Ȃ��A�K�v��������΃R�����g�A�E�g�j
		transform.RotateAround(targetPos, transform.right, -inputY * Time.deltaTime * power);
	}
}
