using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	Vector3 targetPos;

	void Start()
	{
		
	}

	void Update()
	{
		// �}�E�X�̉E�N���b�N�������Ă����
		if (Input.GetMouseButton(1))
		{
			// �}�E�X�̈ړ���
			float mouseInputX = Input.GetAxis("Mouse X");
			float mouseInputY = Input.GetAxis("Mouse Y");
			// target�̈ʒu��Y���𒆐S�ɁA��]�i���]�j����
			transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
			// �J�����̐����ړ��i���p�x�����Ȃ��A�K�v��������΃R�����g�A�E�g�j
			transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);
		}
	}
}
