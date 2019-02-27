using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
using UnityEngine.Networking;

public class PlayerCT : NetworkBehaviour {

	private Rigidbody rb;
	private float maxSpeed=50f;
	public float speed;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	/*void FixedUpdate () {
		float moveHorizontal = CnInputManager.GetAxis ("Horizontal");
		float moveVertical = CnInputManager.GetAxis ("Vertical");


		Vector3 move = new Vector3 (-moveVertical,0.0f,moveHorizontal);
		if (speed < maxSpeed) 
		{
		rb.AddForce(move*speed);
		}
			
	}*/

	void Update()
	{
		float moveHori = CnInputManager.GetAxis ("Horizontal");
		float moveVertical = CnInputManager.GetAxis ("Vertical");

		//transform.Rotate (0, x, 0);
		//transform.Translate (0,0,z);

		Vector3 move = new Vector3 (moveHori, 0f, moveVertical);

		if(speed < maxSpeed)
		{
			rb.AddForce (move*speed);
		}

		while(Input.GetKeyDown(KeyCode.Space))
		{
			Fire ();
		}
	}
	void Fire()
	{
		GameObject bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 10f;

		//NetworkServer.Spawn (bullet);

		Destroy (bullet, 2);
	}

}
