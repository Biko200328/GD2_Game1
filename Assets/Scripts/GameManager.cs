using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//�t���O(proto)
	public bool isProto = false;

	//��
	[SerializeField] private GameObject wall;

	//��
	[SerializeField] private GameObject slope;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1920, 1080, true);
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
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

		if(Input.GetKeyDown(KeyCode.R))
		{
			SceneReset();
		}
	}

	public void ProtoGimmickOn()
	{
		//��������
		if(wall.activeInHierarchy == true)wall.SetActive(false);

		//����㏸������
		Vector3 slopePos = slope.transform.position;
		slopePos.y += 0.02f;
		//�㏸���������
		if(slopePos.y >= 1.3)
		{
			slopePos.y = 1.3f;
		}
		//���l��߂�
		slope.transform.position = slopePos;
	}

	public void ProtoGimmickOff()
	{
		//�����o��������
		if (wall.activeInHierarchy == false) wall.SetActive(true);

		//������~������
		Vector3 slopePos = slope.transform.position;
		slopePos.y -= 0.02f;
		//���~���������
		if (slopePos.y <= -1.27)
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
