using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Pressure : MonoBehaviour
{
	private GameManager gameManager;
	// Start is called before the first frame update
	void Start()
	{
		//����gameManager�ɉ��������Ă��Ȃ�������(null)
		if(gameManager == null)
		{
			GameObject managerObj = GameObject.Find("StageManager");
			gameManager = managerObj.GetComponent<GameManager>();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	//�����蔻��

	//����������
	private void OnTriggerEnter(Collider other)
	{
		//���������������̂�Player��Ball�Ȃ�
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//�쓮������
			gameManager.isProto = true;
		}
	}
	//�����葱���Ă���Ƃ�
	private void OnTriggerStay(Collider other)
	{
		//���������������̂�Player��Ball�Ȃ�
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//�쓮������
			gameManager.isProto = true;
		}
	}
	//������Ȃ��Ȃ�����(�o�Ă�����)
	private void OnTriggerExit(Collider other)
	{
		//���������������̂�Player��Ball�Ȃ�
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//�쓮���~
			gameManager.isProto = false;
		}
	}

	private void hoge()
	{
		CanvasRenderer cr = GetComponent<CanvasRenderer>();
		Material mat = cr.GetMaterial(0);
		mat.SetFloat("_Value", 0.5f);
	}
}
