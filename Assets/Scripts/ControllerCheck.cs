using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{

	//�R���g���[���[���ڑ�����Ă��邩�̃t���O
	public bool isConnection = false;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//�R���g���[���[�ڑ��`�F�b�N
		isConnectController();
	}

	private void isConnectController()
	{
		//�R���g���[���[�̐ڑ��`�F�b�N
		//�ڑ�����Ă���R���g���[���[���(���O)�𓾂�
		string[] cName = Input.GetJoystickNames();
		//�ڑ���
		int currentConnectionCount = 0;
		//�ڑ�����Ă���R���g���[���[�̐����m�F
		for (int i = 0; i < cName.Length; i++)
		{
			//�󔒂̖��O�̂̏������O
			if (cName[i] != "")
			{
				//�ڑ�����1����
				currentConnectionCount++;
			}
		}

		//�ڑ�����1�ȏ�(�R���g���[���[���ڑ�����Ă���Ƃ�)
		if (currentConnectionCount >= 1)
		{
			//�C�ӂ̃t���O��true��
			isConnection = true;
		}
		//�ڑ�����Ă��Ȃ��Ƃ�
		else
		{
			//false��
			isConnection = false;
		}
	}
}
