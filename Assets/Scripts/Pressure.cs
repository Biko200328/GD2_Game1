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
		//もしgameManagerに何も入っていなかったら(null)
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

	//当たり判定

	//当たった時
	private void OnTriggerEnter(Collider other)
	{
		//もし当たったものがPlayerかBallなら
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//作動させる
			gameManager.isProto = true;
		}
	}
	//当たり続けているとき
	private void OnTriggerStay(Collider other)
	{
		//もし当たったものがPlayerかBallなら
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//作動させる
			gameManager.isProto = true;
		}
	}
	//当たらなくなった時(出ていった)
	private void OnTriggerExit(Collider other)
	{
		//もし当たったものがPlayerかBallなら
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//作動を停止
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
