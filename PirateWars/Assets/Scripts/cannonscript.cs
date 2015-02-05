using UnityEngine;
using System.Collections;

public class cannonscript : MonoBehaviour 
{
	public GameObject cannonball;
	public float rateOfFire;
	float fireDelay;
	public float speed;
	void Update()
	{

		if (Input.GetButton ("Fire1") && Time.time > fireDelay) 
		{
			fireDelay = Time.time + rateOfFire;
			GameObject clone = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
			clone.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,speed));
			//Physics.IgnoreCollision (clone.collider, transform.root.collider);
			//audio.Play();
		}
	}
}
