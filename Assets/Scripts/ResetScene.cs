using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

	SceneController sceneController;
	[SerializeField] float deadY = -10f;
	bool isDead = false;

	// Start is called before the first frame update
	void Start()
	{
		GameObject camera = GameObject.Find("Main Camera");
		sceneController = camera.GetComponent<SceneController>();

		isDead = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (this.transform.position.y <= deadY && !isDead)
		{
			isDead = true;
			string activeSceneName = SceneManager.GetActiveScene().name;
			sceneController.sceneChange(activeSceneName);
		}
	}
}
