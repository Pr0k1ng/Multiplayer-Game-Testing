using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour {

    public GUISkin skin;
    public InputField IPADDR_field;
    public InputField PORT_field;

    // Use this for initialization
    void Start () {

        //var input = gameObject.GetComponent<InputField>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {

        NetworkPlayer np = new NetworkPlayer();

        string myIP = np.ipAddress;
        string myIP1 = Network.player.ipAddress;

        GUI.Label(new Rect(150, 10, 600, 300),"MY IP is: " + myIP1);

        GUI.skin = skin;
        GUI.Label(new Rect(10, 10, 300, 80), "MultiPlayer Game");

        GUI.Label(new Rect(10, 50, 400, 30), "Enter IP Address to join");

    
        if (GUI.Button(new Rect(10, 160, 400, 100), "Join Game"))
        {
            string IPADDR = IPADDR_field.text.ToString();
            string PORT = PORT_field.text.ToString();

            if (IPADDR == null)
            {
                IPADDR = myIP1;
            }
            else
            {
                PlayerPrefs.SetString("IPADDR", IPADDR);
            }

            PlayerPrefs.SetString("PORT", PORT);
            //SceneManager.LoadScene("gametest");

            SceneManager.LoadScene("side");
        }

        if (GUI.Button(new Rect(10, 270, 400, 100), "Create Room"))
        {
            SceneManager.LoadScene("side");
        }

        if (GUI.Button(new Rect(10, 380, 400, 100), "QUIT"))
        {
            Application.Quit();
        }
    }

}
