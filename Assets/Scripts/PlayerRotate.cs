using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerRotate : MonoBehaviour {

	float f_lastX = 0.0f;
	float f_difX = 0.5f;
//	float f_steps = 0.0f;
	int i_direction = 1;

	Rect left = new Rect (950f,-60f,50f,50f);
	Rect right = new Rect(1020f,-60f,50f,50f);

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void OnGui()
	{
		
	}


	void Update () 
	{
		
	}

    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            f_difX = 0.0f;
        }
        else if (GUI.Button(left, "left"))
        {
            f_difX = Mathf.Abs(f_lastX - Input.GetAxis("Mouse X"));

            if (f_lastX < Input.GetAxis("Mouse X"))
            {
                i_direction = -1;
                transform.Rotate(Vector3.up, -f_difX);
            }

            if (f_lastX > Input.GetAxis("Mouse X"))
            {
                i_direction = 1;
                transform.Rotate(Vector3.up, f_difX);
            }

            f_lastX = -Input.GetAxis("Mouse X");
        }
        else if (GUI.Button(right, "right"))
        {
            if (f_difX > 0.5f) f_difX -= 0.05f;
            if (f_difX < 0.5f) f_difX += 0.05f;

            transform.Rotate(Vector3.up, f_difX * i_direction);
        }
    }
}