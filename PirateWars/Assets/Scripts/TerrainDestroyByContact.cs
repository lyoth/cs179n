using UnityEngine;
using System.Collections;

public class TerrainDestroyByContact : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;
	public float bounce;
	void OnTriggerEnter(Collider other) 
	{
		//ignores ships
		if (other.tag == "Player") 
		{
			//player loses health, bounces off terrain
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent <PlayerHealth> ();
			other.collider.rigidbody.velocity = new Vector3((-bounce)*other.collider.rigidbody.velocity.x, 0, (-bounce)*other.collider.rigidbody.velocity.z) ;
			playerHealth.TakeDamage(10);

		} 
		else if(other.tag == "Enemy")
		{
			//damage to enemy
		}
	}
}
