using UnityEngine;
using System.Collections;

public class CannonballCollisionEnemy : MonoBehaviour {
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
	public GameObject explosion2;
	
	void OnTriggerEnter(Collider other) 
	{
		print (other + "\t" + other.tag);
		if (other.tag == "PlayerShip" | other.tag == "Player") 
		{
			print ("HIT TAKEN");
			//damage to player
			player = GameObject.FindGameObjectWithTag ("Player");
			//TODO: add back in health
			//playerHealth = player.GetComponent <PlayerHealth> ();
			//playerHealth.TakeDamage(25);
			
			//call explosion animation
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			//Despawn cannonball
			Destroy (gameObject);
			Application.LoadLevel("Game Lost");
		}
		
		else if (other.tag == "Terrain")
		{
			//call explosion animation for terrain
			Instantiate(explosion2, gameObject.transform.position, other.transform.rotation);
			//despawn cannonball
			Destroy (gameObject);
		}
		else if (other.tag == "Water")
		{
			//splash!
			
			//despawn cannonball
			Destroy (gameObject);
		}
	}
}