using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

	public float deadY = -10;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(this.transform.position.y <= deadY)
		{
			string activeSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(activeSceneName);
		}
	}
}
