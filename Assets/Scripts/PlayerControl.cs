using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
using UnityEngine.Networking;

public class PlayerControl : NetworkBehaviour {

	private Rigidbody rb;
	private float maxSpeed=50f;
	public float speed;
    public float torque;
    float smooth = 5.0f;

    public GameObject bulletPrefab;
	public Transform bulletSpawn;
    public Transform tb;
    

    //public float speed = 20;
    PhotonView pv;

    void Start () {
		rb = GetComponent<Rigidbody> ();
        pv = this.GetComponent<PhotonView>();
        tb = this.GetComponent<Transform>();
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
		float moveHori, moveVertical;

        moveHori = CnInputManager.GetAxis("Horizontal");
        moveVertical = CnInputManager.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHori, 0.0f, moveVertical); ;

		//transform.Rotate (0, x, 0);
		//transform.Translate (0,0,z);

        if(PlayerPrefs.GetString("BlueSide") == "blue")
        {
            move = new Vector3(moveHori, 0.0f, moveVertical);
        }
		else if(PlayerPrefs.GetString("OrangeSide") == "orange")
        {
            move = new Vector3(-moveHori, 0.0f, -moveVertical);
        }

		if(speed < maxSpeed)
		{
			rb.AddForce (move*speed);
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			
		}

		//if (rb.transform.rotation.y == -180f) 
		//{
		//	rb.GetComponentInChildren<Canvas> ().transform.rotation.y = -180f;
		//}
	}

	/*void Fire()
	{
		GameObject bullet = (GameObject)Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 10f;

		//NetworkServer.Spawn (bullet);

        //PhotonNetwork.Instantiate();

		Destroy (bullet, 2);
	}*/

    public void OnGUI()
    {

        float turnLeft = CnInputManager.GetAxis("Horizontal") * torque;
        

        //float moveHori = CnInputManager.GetAxis("Horizontal");
        float turnRight = CnInputManager.GetAxis("Vertical") * -10.0f;

        while (GUI.Button(new Rect(700, 300, 30, 30), "Fire"))
        {
            //Fire();
            pv.RPC("Shoot", PhotonTargets.All);
        }

        while (GUI.Button(new Rect(600, 300, 30, 30), "Left"))
        {
            //rb.AddTorque(transform.up * torque * turn);

            //rb.AddTorque(0,torque,0, ForceMode.Force);

            //Qaternion target = Quaternion.Euler(0, turnLeft, 0);

            // Dampen towards the target rotation
            //tansform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

            tb.Rotate(new Vector3(0, tb.rotation.y - 10, 0));
        }

        while (GUI.Button(new Rect(800, 300, 30, 30), "Right"))
        {
            //transform.Rotate(0,-moveHori, 0);

            //Quaternion target = Quaternion.Euler(0, -turnRight, 0);

            // Dampen towards the target rotation
            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

            tb.Rotate(new Vector3(0, tb.rotation.y + 10, 0));

        }
    }

    [PunRPC]
    void Shoot()
    {
        Debug.Log("shoot");
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10f;
        Destroy(bullet, 2);
    }

}


