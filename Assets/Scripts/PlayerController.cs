using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//�v���C���[�̈ړ��X�s�[�h
	[SerializeField] private float speed;

	//�ړ��W��
	private float move = 1.0f;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//position�u������
		Vector3 pos = this.transform.position;

		//�΂ߓ��͎��̈ړ����xDown
		if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true)
		{
			if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true)
			{
				//�ړ��W����0.71�ɐݒ�
				move = 0.71f;
			}
			else
			{
				//�΂߂���Ȃ����1.0�ɐݒ�
				move = 1.0f;
			}

		}
		else if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true)
		{
			move = 1.0f;
		}

		//�ړ�����
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
		{
			pos.x += -1 * speed * move;
		}
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
		{
			pos.x += 1 * speed * move;
		}
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)
		{
			pos.z += 1 * speed * move;
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)
		{
			pos.z += -1 * speed * move;
		}

		//���l��߂�
		transform.position = pos;
	}
}
