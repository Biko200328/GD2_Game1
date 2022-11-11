using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	[SerializeField] private GameObject Clear;
	PlayerController playerController;

	// Start is called before the first frame update
	void Start()
	{
		GameObject player = GameObject.Find("Player");
		playerController = player.GetComponent<PlayerController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Ball")
		{
			Clear.SetActive(true);
			playerController.isClear = true;
		}
	}
}
