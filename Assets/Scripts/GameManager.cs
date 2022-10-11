using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//フラグ(proto)
	public bool isProto = false;

	//壁
	[SerializeField] private GameObject wall;

	//坂
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

		if(Input.GetKeyDown(KeyCode.R))
		{
			SceneReset();
		}
	}

	public void ProtoGimmickOn()
	{
		//扉を消す
		if(wall.activeInHierarchy == true)wall.SetActive(false);

		//坂を上昇させる
		Vector3 slopePos = slope.transform.position;
		slopePos.y += 0.02f;
		//上昇上限をつける
		if(slopePos.y >= 1.3)
		{
			slopePos.y = 1.3f;
		}
		//数値を戻す
		slope.transform.position = slopePos;
	}

	public void ProtoGimmickOff()
	{
		//扉を出現させる
		if (wall.activeInHierarchy == false) wall.SetActive(true);

		//坂を下降させる
		Vector3 slopePos = slope.transform.position;
		slopePos.y -= 0.02f;
		//下降上限をつける
		if (slopePos.y <= -1.27)
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
