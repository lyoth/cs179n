using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	private GameObject player;							// Reference to the player.
	//private NavMeshAgent nav;								// Reference to the nav mesh agent.
	public float patrolSpeed = 10f;							// The nav mesh agent's speed when patrolling.
	public float rotationSpeed = 2f;						
	public float chaseSpeed = 5f;							// The nav mesh agent's speed when chasing.
	//public float chaseWaitTime = 5f;						// The amount of time to wait when the last sighting is reached.
	//public float patrolWaitTime = 1f;						// The amount of time to wait when the patrol way point is reached.
	//private float chaseTimer;								// A timer for the chaseWaitTime.
	//private float patrolTimer;								// A timer for the patrolWaitTime.

	//way point information
	public Transform[] patrolWayPoints;						// An array of transforms for the patrol route.
	private int wayPointIndex;								// A counter for the way point array.
	private Transform wayPoint;
	private float distanceToDestination;

	//state information
	private string PATROL = "PATROL";
	private string CHASE = "CHASE";
	private string state;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		wayPointIndex = -1;
		distanceToDestination = 0;
		state = PATROL; // start as patrolling enemies
	}

	void Awake() {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		//nav = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
//		if (wayPoint != null) {
//			print ("State: " + state + "\t" + transform.position + "\t" + distanceToDestination + "\t" + wayPoint.position);
//		}

		if (state.Equals(PATROL)) {
			Patrolling ();
		}
		else if (state.Equals(CHASE)) {
			Chasing();
		}
	}

//	void OnTriggerEnter(Collider other) {
//		//print ("OnTriggerEnter " + other.gameObject + "\t" + other);
//	}
//
//	void OnTriggerStay (Collider other)
//	{
//		if (other.gameObject == player) {
//			//print ("Player is in Arena!");
//			Chasing();
//		}
//	}
//	
//	
//	void OnTriggerExit (Collider other)
//	{
//		Patrolling ();
//		//print ("OnTriggerExit");
//	}

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
				state = "NONE";
			}
			else {
				wayPoint = patrolWayPoints[wayPointIndex];
				//transform.LookAt (wayPoint.position);
			}
		}
		//TODO: get rotation working correctly
		//create the rotation we need to be in to look at the target
		//Quaternion rotation = Quaternion.LookRotation(wayPoint.position - transform.position);
		//rotate us over time according to speed until we are in the required rotation
		//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
	
		//print ("Transform Rotate (b): " + transform.rotation + "\t" + rotation);
		//transform.Rotate (new Vector3(270, transform.rotation.y - rotation.y, transform.rotation.z - rotation.z));
		//transform.RotateAround (transform.position, rotation, Time.deltaTime * rotationSpeed);
		//transform.rotation.Set (transform.rotation.w, rotation.x, transform.rotation.y, rotation.z);
		//print ("Transform Rotate (a): " + transform.rotation + "\t" + rotation);
		//transform.rotation = rotation;

		// Move our position a step closer to the target.
		Move (transform, wayPoint, patrolSpeed);
		//transform.position = Vector3.MoveTowards(transform.position, wayPoint.position, patrolSpeed * Time.deltaTime);
	}

	Quaternion Rotate(Transform start, Transform destination) {
		print ("Start: " + start.localPosition + "\t" + destination.localPosition);
		print ("\tPosition: " + start.position + "\t" + destination.position);
		print ("\tRotation (local): " + start.localRotation + "\t" + destination.localRotation);
		print ("\tRotation: " + start.rotation + "\t" + destination.rotation);
		Vector3 heading = start.position - destination.position;
		print ("\tHeading: " + heading + "\tAngle: " + Vector3.Angle(start.position, destination.position));
		return start.rotation;
	}


 	void Move(Transform current, Transform destination, float speed) {
		transform.rotation = Rotate (current, destination);
//		Transform offset = transform;
//		offset.
//		offset.position.x = offset.position.x + (float) 2.15;
//		offset.position.y = offset.position.y - (float) 1.47;
//		offset.position.z = offset.position.z + (float) 5.25;
//		print ("Position (w/out) offset: " + transform.position + "\t(w/) " + offset.position);
		//Quaternion rotation = Quaternion.LookRotation(wayPoint.position - offset.position);
		//print ("Rotation: (before): " + rotation.y);
//		rotation.y = rotation.y -  180;
//		if (rotation.y > 180) {
//
//		}
//		double offset = -0.7071068;
//		rotation.y = rotation.y + (float) offset;
		//print ("\t\tRotation: (after): " + rotation.y + "\t" + rotation);
		//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
//		Vector3 targetDir = wayPoint.position - transform.position;
//		float step = speed * Time.deltaTime;
//		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
//		print ("Old: " + transform.rotation + "\t" + Quaternion.LookRotation(newDir));
//		transform.rotation = Quaternion.LookRotation(newDir);
		
		
		distanceToDestination = Vector3.Distance (transform.position, wayPoint.position);
		transform.position = Vector3.MoveTowards(current.position, destination.position, speed * Time.deltaTime);
		//print ("Transform: " + transform.position + "\t" + distanceToDestination);
	}
}
