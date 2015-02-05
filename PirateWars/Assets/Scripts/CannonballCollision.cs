﻿using UnityEngine;
using System.Collections;

public class CannonballCollision : MonoBehaviour {
	/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

	public GameObject explosion;
	public GameObject explosion2;

	void OnTriggerEnter(Collider other) 
	{

		if(other.tag == "EnemyShip")
		{
			//damage to enemy
			print ("hit!");
			//call explosion animation
			Instantiate(explosion, gameObject.transform.position, other.transform.rotation);
			//despawn cannonball
			Destroy (gameObject);

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