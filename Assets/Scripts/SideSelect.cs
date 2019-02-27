using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SideSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGUI()
    {
        if (GUI.Button(new Rect(10, 160, 400, 100), "Blue Team"))
        {
            PlayerPrefs.SetString("BlueSide" , "blue");
            PlayerPrefs.SetString("OrangeSide", "");
            SceneManager.LoadScene("gametest");
        }

        if (GUI.Button(new Rect(10, 270, 400, 100), "Orange Team"))
        {
            PlayerPrefs.SetString("OrangeSide", "orange");
            PlayerPrefs.SetString("BlueSide", "");
            SceneManager.LoadScene("gametest");
        }
    }
}
