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

		if(gameManager.isConnection == false)
		{
			// �}�E�X�̍��N���b�N�������Ă����
			if (Input.GetMouseButton(0))
			{
				// �}�E�X�̈ړ���
				float mouseInputX = Input.GetAxis("Mouse X");
				float mouseInputY = Input.GetAxis("Mouse Y");
				// target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
				transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
				// �J�����̐����ړ��i���p�x�����Ȃ��A�K�v��������΃R�����g�A�E�g�j
				transform.RotateAround(targetPos, transform.right, -mouseInputY * Time.deltaTime * 200f);
			}
		}
		else
		{
			float cInputX = Input.GetAxis("cHorizontalR");
			float cInputY = Input.GetAxis("cVerticalR");
			// target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
			transform.RotateAround(targetPos, Vector3.up, cInputX * Time.deltaTime * 200f);
			// �J�����̐����ړ��i���p�x�����Ȃ��A�K�v��������΃R�����g�A�E�g�j
			transform.RotateAround(targetPos, transform.right, -cInputY * Time.deltaTime * 200f);
		}
	}
}
