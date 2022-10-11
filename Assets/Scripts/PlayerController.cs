using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//プレイヤーの移動スピード
	[SerializeField] private float speed;

	//移動係数
	private float move = 1.0f;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//position置き換え
		Vector3 pos = this.transform.position;

		//斜め入力時の移動速度Down
		if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true)
		{
			if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true)
			{
				//移動係数を0.71に設定
				move = 0.71f;
			}
			else
			{
				//斜めじゃなければ1.0に設定
				move = 1.0f;
			}

		}
		else if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true)
		{
			move = 1.0f;
		}

		//移動処理
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

		//数値を戻す
		transform.position = pos;
	}
}
