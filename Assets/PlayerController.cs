using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed;

	//ˆÚ“®ŒW”
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
				//ˆÚ“®ŒW”‚ğ‚OD‚V‚P‚Éİ’è
				move = 0.71f;
			}
			else
			{
				//Î‚ß‚¶‚á‚È‚¯‚ê‚Î‚PD‚O‚Éİ’è
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
