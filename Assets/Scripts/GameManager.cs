using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class GameManager : MonoBehaviour
{
	//フラグ(proto)
	public bool isProto = false;

	//壁
	[SerializeField] private GameObject wall;

	//坂
	[SerializeField] private GameObject slope;

	//コントローラーが接続されているかのフラグ
	public bool isConnection = false;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1920, 1080, true);
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
		//コントローラー接続チェック
		isConnectController();

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

	private void isConnectController()
	{
		//コントローラーの接続チェック
		//接続されているコントローラー情報(名前)を得る
		string[] cName = Input.GetJoystickNames();
		//接続数
		int currentConnectionCount = 0;
		//接続されているコントローラーの数を確認
		for (int i = 0; i < cName.Length; i++)
		{
			//空白の名前のの情報を除外
			if (cName[i] != "")
			{
				//接続数を1足す
				currentConnectionCount++;
			}
		}

		//接続数が1以上(コントローラーが接続されているとき)
		if (currentConnectionCount >= 1)
		{
			//任意のフラグをtrueに
			isConnection = true;
		}
		//接続されていないとき
		else
		{
			//falseに
			isConnection = false;
		}
	}
}
