using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//フラグ(proto)
	public bool isProto = false;

	//壁
	[SerializeField] private GameObject wall;

	//坂
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
			describe.text = "Lスティックでプレイヤー移動\r\nRスティックでカメラ移動";
		}
		else
		{
			describe.text = "十字もしくはWASDでプレイヤー移動\r\n左クリック長押しでカメラ操作";
		}

		//on(感圧版にのっている)時
		if (isProto == true)
		{
			//On時処理を実行させる
			ProtoGimmickOn();
		}
		//off(のっていない)時
		else
		{
			//Off時処理を実行させる
			ProtoGimmickOff();
		}

		//Rキーでシーンリセット
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneReset();
		}
	}

	public void ProtoGimmickOn()
	{
		//扉を下降させる
		Vector3 wallPos = wall.transform.position;
		wallPos.y -= 0.02f;
		//下降上限をつける
		if (wallPos.y <= -1.23f)
		{
			wallPos.y = -1.23f;
		}
		//数値を戻す
		wall.transform.position = wallPos;

		//坂を上昇させる
		Vector3 slopePos = slope.transform.position;
		slopePos.y += 0.02f;
		//上昇上限をつける
		if(slopePos.y >= 1.3f)
		{
			slopePos.y = 1.3f;
		}
		//数値を戻す
		slope.transform.position = slopePos;
	}

	public void ProtoGimmickOff()
	{
		//扉を上昇させる
		Vector3 wallPos = wall.transform.position;
		wallPos.y += 0.02f;
		//下降上限をつける
		if (wallPos.y >= 1.28f)
		{
			wallPos.y = 1.28f;
		}
		//数値を戻す
		wall.transform.position = wallPos;



		//坂を下降させる
		Vector3 slopePos = slope.transform.position;
		slopePos.y -= 0.02f;
		//下降上限をつける
		if (slopePos.y <= -1.27f)
		{
			slopePos.y = -1.27f;
		}
		//数値を戻す
		slope.transform.position = slopePos;
	}

	public void SceneReset()
	{
		string activeSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(activeSceneName);
	}
}
