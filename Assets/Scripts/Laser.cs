using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
	bool isDes;
	bool reset;

	float timer;

	SceneController sceneController;
	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
		reset = false;

		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();
	}

	// Update is called once per frame
	void Update()
	{
		if(isDes && reset == false)
		{
			timer+=Time.deltaTime;
			if(timer>= 2)
			{
				string activeSceneName = SceneManager.GetActiveScene().name;
				sceneController.sceneChange(activeSceneName);
				reset = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Ball")
		{
			Destroy(other.gameObject);
			isDes = true;
		}
	}
}
