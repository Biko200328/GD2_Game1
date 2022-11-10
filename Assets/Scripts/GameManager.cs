using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//�t���O(proto)
	public bool isProto = false;

	//��
	[SerializeField] private GameObject wall;

	//��
	[SerializeField] private GameObject slope;

	[SerializeField] Text describe;

	ControllerCheck controllerCheck;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1920, 1080, false);
		Application.targetFrameRate = 60;

		controllerCheck = gameObject.GetComponent<ControllerCheck>();
	}

	// Update is called once per frame
	void Update()
	{
		if(controllerCheck.isConnection)
		{
			describe.text = "L�X�e�B�b�N�Ńv���C���[�ړ�\r\nR�X�e�B�b�N�ŃJ�����ړ�";
		}
		else
		{
			describe.text = "�\����������WASD�Ńv���C���[�ړ�\r\n���N���b�N�������ŃJ��������";
		}

		//on(�����łɂ̂��Ă���)��
		if (isProto == true)
		{
			//On�����������s������
			ProtoGimmickOn();
		}
		//off(�̂��Ă��Ȃ�)��
		else
		{
			//Off�����������s������
			ProtoGimmickOff();
		}

		//R�L�[�ŃV�[�����Z�b�g
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneReset();
		}
	}

	public void ProtoGimmickOn()
	{
		//�������~������
		Vector3 wallPos = wall.transform.position;
		wallPos.y -= 0.02f;
		//���~���������
		if (wallPos.y <= -1.23f)
		{
			wallPos.y = -1.23f;
		}
		//���l��߂�
		wall.transform.position = wallPos;

		//����㏸������
		Vector3 slopePos = slope.transform.position;
		slopePos.y += 0.02f;
		//�㏸���������
		if(slopePos.y >= 1.3f)
		{
			slopePos.y = 1.3f;
		}
		//���l��߂�
		slope.transform.position = slopePos;
	}

	public void ProtoGimmickOff()
	{
		//�����㏸������
		Vector3 wallPos = wall.transform.position;
		wallPos.y += 0.02f;
		//���~���������
		if (wallPos.y >= 1.28f)
		{
			wallPos.y = 1.28f;
		}
		//���l��߂�
		wall.transform.position = wallPos;



		//������~������
		Vector3 slopePos = slope.transform.position;
		slopePos.y -= 0.02f;
		//���~���������
		if (slopePos.y <= -1.27f)
		{
			slopePos.y = -1.27f;
		}
		//���l��߂�
		slope.transform.position = slopePos;
	}

	public void SceneReset()
	{
		string activeSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(activeSceneName);
	}
}
