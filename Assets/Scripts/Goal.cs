using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	[SerializeField] private GameObject Clear;
	PlayerController playerController;

	public AudioSource clearBGM;

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
			clearBGM.Play();
			Clear.SetActive(true);
			playerController.isClear = true;
		}
	}
}
