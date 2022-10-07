using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
		Vector3 pos = this.transform.position;

		if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true)
		{
			if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true)
			{
				//移動係数を０．７１に設定
				move = 0.71f;
			}
			else
			{
				//斜めじゃなければ１．０に設定
				move = 1.0f;
			}

		}
		else if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true)
		{
			move = 1.0f;
		}

		if (Input.GetKey(KeyCode.A))
		{
			pos.x += -1 * speed * move;
		}
		if (Input.GetKey(KeyCode.D))
		{
			pos.x += 1 * speed * move;
		}
		if (Input.GetKey(KeyCode.W))
		{
			pos.z += 1 * speed * move;
		}
		if (Input.GetKey(KeyCode.S))
		{
			pos.z += -1 * speed * move;
		}

		transform.position = pos;
	}
}
