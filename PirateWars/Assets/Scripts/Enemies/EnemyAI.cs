using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	private GameObject player;							
	public float patrolSpeed = 7f;							
	public float rotationSpeed;
	public float chaseSpeed = 5f;	
	public float firingRange = 80;

	//way point information
	public Transform[] patrolWayPoints;				
	private int wayPointIndex;								
	private Transform wayPoint;
	private float distanceToDestination;

	//state information
	private string PATROL = "PATROL";
	private string CHASE = "CHASE";
	private string ATTACK = "ATTACK";
	private string state;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		wayPointIndex = -1;
		distanceToDestination = 0;
		state = PATROL; // start as patrolling enemies
	}

	void Awake() {
		//player = GameObject.FindGameObjectWithTag(Tags.player);
	}

	// Update is called once per frame
	void Update () {
		print (state + "\t" + distanceToDestination + "\t" + firingRange);
		if (state.Equals (ATTACK)) {
			Attacking();
		} else if (state.Equals(CHASE)) {
			Chasing();
		} else if (state.Equals (PATROL)) {
			Patrolling ();
		}
	}

	void OnTriggerEnter(Collider other) {
		//print ("OnTriggerEnter " + other.gameObject + "\t" + other);
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == player) {
			if (state.Equals(PATROL) || distanceToDestination > firingRange){ 
				Chasing();
			} else if (distanceToDestination <= firingRange) {
				Attacking();
			}
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			Patrolling ();
		}
	}

	void Attacking() {
		state = ATTACK;
		print ("Time to attack!!");
	}

	void Chasing() {
		state = CHASE;
		Move (transform, player.transform, chaseSpeed);
	}
	
	void Patrolling ()
	{
		state = PATROL;
		if (distanceToDestination == 0) {
			//print ("State is NONE");
			//state = "NONE";
			//int rand = Random.Range(0, patrolWayPoints.Length - 1);
			//while (rand == wayPointIndex) 
			//	rand = Random.Range(0, patrolWayPoints.Length - 1);
			//wayPointIndex = rand;
			wayPointIndex++;
			if (wayPointIndex == patrolWayPoints.Length) {
				wayPointIndex = 0;
			}
			else {
				wayPoint = patrolWayPoints[wayPointIndex];

			}
		}

		Move (transform, wayPoint, patrolSpeed);
	}
	
 	void Move(Transform current, Transform destination, float speed) {
		if (destination.position - transform.position != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(destination.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}

		distanceToDestination = Vector3.Distance (transform.position, destination.position);
		transform.position = Vector3.MoveTowards(current.position, destination.position, speed * Time.deltaTime);
	}
}
