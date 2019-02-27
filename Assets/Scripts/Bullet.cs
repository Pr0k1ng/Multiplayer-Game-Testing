using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Photon.PunBehaviour {


    void OnCollisionEnter(Collision other)
	{
        Destroy(gameObject);
        Debug.Log("Collided");
        GameObject hit = other.gameObject;

        Debug.Log("Got Player");

		Health health = hit.GetComponent<Health> ();
		//Health h = new Health();
		if (health != null) 
		{
            health.TakeDamage (10);

            //photonView.RPC("health.TakeDamage", PhotonTargets.All, 10);

            //pv.RPC("damage", PhotonTargets.All);

        }
		
	}
}
