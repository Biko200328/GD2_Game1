using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
	//[SerializeField]GameObject obj;
	//[SerializeField]CanvasRenderer cr;
	[SerializeField] Material mat;
	[SerializeField]Shader shader;

	float value;

	// Start is called before the first frame update
	void Start()
    {
		//cr = obj.GetComponent<CanvasRenderer>();
		shader = mat.shader;
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKey(KeyCode.A))
		{
			value -= 0.015f;
			if(value <= 0)
			{
				value = 0;
			}
		}
		else if (Input.GetKey(KeyCode.D))
		{
			value += 0.015f;
			if(value >= 0.71f)
			{
				value = 0.71f;
			}
		}
		mat.SetFloat("_Value", value);
    }
}
