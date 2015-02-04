using UnityEngine;
using System.Collections;

public class EnemyCannon : MonoBehaviour {

	public GameObject cannonball;
	public float rateOfFire;
	//float fireDelay;
	public float speed;
	public Transform enemyShip;
	private EnemyAI enemyAIscript;
	private float fire;

	// Use this for initializationf
	void Start () {
		enemyAIscript = enemyShip.GetComponent<EnemyAI>();
	}
	
	void Update()
	{
		//print ("Is in attack state? " + enemyAIscript.isAttackState() + "\t" + Time.time + "\t" + fire);
		if (enemyAIscript.isAttackState() && enemyAIscript.userInSight() && Time.time > fire) {
			fire = Time.time + rateOfFire;
			GameObject clone = (GameObject)Instantiate (cannonball, transform.position, transform.rotation);
			clone.rigidbody.velocity = transform.TransformDirection (new Vector3(0,0,speed));
			Physics.IgnoreCollision (clone.collider, enemyShip.transform.collider);
		}
	}
}
