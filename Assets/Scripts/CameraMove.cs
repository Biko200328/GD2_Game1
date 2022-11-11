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

	// �O���̊�ƂȂ郍�[�J����ԃx�N�g��
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
			// target�̈ړ��ʕ��A�����i�J�����j���ړ�����
			// ���̂܂ܓ����ƃv���C���[�������Ȃ��Ȃ�̂łƂ肠�����ړ����x��1/2��
			transform.position += (targetObj.transform.position - targetPos) / 2;
			targetPos = targetObj.transform.position;

			float inputX = 0f, inputY = 0f, power = 0f;

			if (controllerCheck.isConnection == false)
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
				//�R���g���[���[
				power = 100f;
				inputX = Input.GetAxis("cHorizontalR");
				inputY = Input.GetAxis("cVerticalR");
			}

			// target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
			transform.RotateAround(targetPos, Vector3.up, inputX * Time.deltaTime * power);
			// �J�����̐����ړ��i���p�x�����Ȃ��A�K�v��������΃R�����g�A�E�g�j
			transform.RotateAround(targetPos, transform.right, -inputY * Time.deltaTime * power);


			//�����_�����������Ɍ����������ŕς��Ă�����
			// �^�[�Q�b�g�ւ̌����x�N�g���v�Z
			var dir = targetPos - this.transform.position;

			// �^�[�Q�b�g�̕����ւ̉�]
			var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);
			// ��]�␳
			var offsetRotation = Quaternion.FromToRotation(_forward, Vector3.forward);

			// ��]�␳���^�[�Q�b�g�����ւ̉�]�̏��ɁA���g�̌����𑀍삷��
			this.transform.rotation = lookAtRotation * offsetRotation;
		}
	}
}
