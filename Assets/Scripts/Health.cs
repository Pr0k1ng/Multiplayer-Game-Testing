using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : Photon.PunBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    PhotonView pv;


    public void TakeDamage(int amount)
    {
        Debug.Log(amount.ToString());

        currentHealth -= amount;

        photonView.RPC("OnChangeHealth", PhotonTargets.All, currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            RpcRespawn();

        }

    }

    [PunRPC]
	void OnChangeHealth(int health)
	{
		healthBar.sizeDelta = new Vector2 (health*2 , healthBar.sizeDelta.y);
	}

	[PunRPC]
	void RpcRespawn()
	{
		if (photonView.isMine) 
		{
			transform.position = Vector3.zero;
		}
	}
}
