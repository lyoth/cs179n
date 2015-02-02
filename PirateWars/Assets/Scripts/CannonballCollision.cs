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
	public GameObject explosion;

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
			Instantiate(explosion, other.transform.position, other.transform.rotation);
		}

		else if(other.tag == "EnemyShip")
		{
			//damage to enemy

			//call explosion animation?
			//despawn cannonball
			Destroy (gameObject);
			Instantiate(explosion, other.transform.position, other.transform.rotation);
		}
	}
}