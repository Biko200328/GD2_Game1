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
		//‚à‚µgameManager‚É‰½‚à“ü‚Á‚Ä‚¢‚È‚©‚Á‚½‚ç(null)
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

	//“–‚½‚è”»’è

	//“–‚½‚Á‚½
	private void OnTriggerEnter(Collider other)
	{
		//‚à‚µ“–‚½‚Á‚½‚à‚Ì‚ªPlayer‚©Ball‚È‚ç
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//ì“®‚³‚¹‚é
			gameManager.isProto = true;
		}
	}
	//“–‚½‚è‘±‚¯‚Ä‚¢‚é‚Æ‚«
	private void OnTriggerStay(Collider other)
	{
		//‚à‚µ“–‚½‚Á‚½‚à‚Ì‚ªPlayer‚©Ball‚È‚ç
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//ì“®‚³‚¹‚é
			gameManager.isProto = true;
		}
	}
	//“–‚½‚ç‚È‚­‚È‚Á‚½(o‚Ä‚¢‚Á‚½)
	private void OnTriggerExit(Collider other)
	{
		//‚à‚µ“–‚½‚Á‚½‚à‚Ì‚ªPlayer‚©Ball‚È‚ç
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ball")
		{
			//ì“®‚ğ’â~
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
