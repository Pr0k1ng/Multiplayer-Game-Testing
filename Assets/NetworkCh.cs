using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCh : Photon.MonoBehaviour {

	Vector3 realPositon = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!photonView.isMine) 
		{
			transform.position = Vector3.Lerp (transform.position, realPositon,0.1f);
			transform.rotation = Quaternion.Lerp(transform.rotation,realRotation,0.1f);
		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
		} else {
			realPositon = (Vector3)stream.ReceiveNext ();
			realRotation = (Quaternion)stream.ReceiveNext ();
		}
	}
}
