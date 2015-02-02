using UnityEngine;
using System.Collections;

public class CannonballCollision : MonoBehaviour {
	/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

	GameObject player;
	PlayerHealth playerHealth;

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
		{
			//damage to player
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();
			playerHealth.TakeDamage(25);

			//call explosion animation?
			//Despawn cannonball
			Destroy (gameObject);
		}

		else if(other.tag == "Enemy")
		{
			//damage to enemy

			//call explosion animation?
			//despawn cannonball
			Destroy (gameObject);
		}
	}
}