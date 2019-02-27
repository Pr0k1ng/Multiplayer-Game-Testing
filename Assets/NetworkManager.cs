using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

	public GameObject standByCamera;
    public SpawnSpot[] spawnBlue;
    public SpawnSpot[] spawnOrange;

    //public GameObject joystickPanel;
    //public RectTransform JoystickTransform;

    // Use this for initialization

    

	void Start () 
	{
		Connect ();
	}
		
	void Connect()
	{
        string localIP = "192.168.0.102";

        int localPort;

        if (PlayerPrefs.GetString("IPADDR") == null)
        {
            localIP = Network.player.ipAddress;
        }
        else
        {
            localIP = PlayerPrefs.GetString("IPADDR");
        }

        if (PlayerPrefs.GetString("PORT") == null)
        {
            localPort = 25000;
        }
        else
        {
            localPort = Convert.ToInt32(PlayerPrefs.GetString("PORT"));
        }

        
        PhotonNetwork.ConnectUsingSettings ("MultiFPS v001");
		PhotonNetwork.ConnectToMaster (localIP, localPort,"9ba5c357-0510-4d67-9d99-f3883b072bd5","MultiFPS v001");
	}

	void OnGUI()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString());
	}

	private void OnConnectedToMaster() 
	{
		PhotonNetwork.JoinLobby();
	}

	void OnJoinedLobby()
	{
		Debug.Log ("Random Lobby Joined");
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed()
	{
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom()
	{
		Debug.Log ("Room Joined");
		SpawnMyPlayer ();
	}

	void SpawnMyPlayer()
	{
        Quaternion rotation = new Quaternion();
        rotation.Set(0,180,0,1);

        if (spawnBlue == null && spawnOrange == null) 
		{
			Debug.LogError ("?????");
			return;
		}

        if (PlayerPrefs.GetString("BlueSide") == "blue")
        {
            SpawnSpot mySpawnSpot = spawnBlue[UnityEngine.Random.Range(0, spawnBlue.Length)];

            

            GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate("PlayerBlue", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
            standByCamera.SetActive(false);

            //myPlayerGO.GetComponent<NetworkCharacter> ().enabled = true;
            myPlayerGO.GetComponent<PlayerControl>().enabled = true;
            //myPlayerGO.GetComponent<PlayerRotate> ().enabled = true;
            myPlayerGO.GetComponentInChildren<Camera>().enabled = true;
            myPlayerGO.GetComponentInChildren<Canvas>().enabled = true;

        }
        else if(PlayerPrefs.GetString("OrangeSide") == "orange")
        {
            SpawnSpot mySpawnSpot = spawnOrange[UnityEngine.Random.Range(0, spawnOrange.Length)];

            GameObject myPlayerGO = (GameObject)PhotonNetwork.Instantiate("PlayerOrange", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
            standByCamera.SetActive(false);

            //myPlayerGO.GetComponent<NetworkCharacter> ().enabled = true;
            myPlayerGO.GetComponent<PlayerControl>().enabled = true;
            //myPlayerGO.GetComponent<PlayerRotate> ().enabled = true;
            myPlayerGO.GetComponentInChildren<Camera>().enabled = true;
            myPlayerGO.GetComponentInChildren<Canvas>().enabled = true;
        }

        

		//GameObject Joystick = (GameObject)Instantiate (joystickPanel, JoystickTransform.position, JoystickTransform.rotation);
	}
}
