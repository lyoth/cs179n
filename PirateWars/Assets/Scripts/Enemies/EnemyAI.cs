using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	private GameObject player;							
	public float rotationSpeed;
	public float chaseSpeed; // = 5f;	
	public float patrolSpeed; // = 7f;	
	public float attackSpeed;
	public float firingRange; // = 80;

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

	//attack information
	private ArrayList barrierPoints;
	private Bounds attackBarrier;
	private Vector3 attackPosition;
	private float attackDistance;

	public bool userInSight() {
		//TODO:
		return true;
	}

	public bool isAttackState() {
		return (state.Equals(ATTACK)) ? true : false;
	}

	// Use thisw for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.playerShip);
		wayPointIndex = -1;
		distanceToDestination = 0;

		barrierPoints = new ArrayList ();

		//attack inits
		attackDistance = 1000;

		state = PATROL; // start as patrolling enemies
	}


	void Awake() {
		//player = GameObject.FindGameObjectWithTag(Tags.player);
	}

	// Update is called once per frame
	void Update () {
		//print (state);
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
//		if (other.gameObject == player) {
//			Chasing();		
//		}
	}

	void OnTriggerStay (Collider other)
	{
		//print ("OnTriggerStay " + other.gameObject + "\t" + other);
		if (other.gameObject == player) {
			float distance = Vector3.Distance (transform.position, player.transform.position);
			//print ("Distance" + distance + "\t" + firingRange + "\t" + state);
			if (distance > firingRange * 2){ 
				Chasing();
			} else {
				Attacking();
			}
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) {
			ClearAttack();
			Patrolling ();
		}
	}

	//TODO: change things up
	public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
		Vector3 dir = point - pivot; // get point direction relative to pivot
		dir = Quaternion.Euler(angles) * dir; // rotate it
		point = dir + pivot; // calculate rotated point
		return point; // return it
	}

	void ConstructBarrier() {
		barrierPoints.Clear ();
		Vector3 center = player.transform.position;
		Vector3 left = center;
		Vector3 right = center;
		Vector3 top = center;
		Vector3 bottom = center;
		left.x = left.x - firingRange;
		right.x = right.x + firingRange;
		top.z = top.z + firingRange;
		bottom.z = bottom.z - firingRange;

		barrierPoints.Add (left);
		barrierPoints.Add (right);
		barrierPoints.Add (top);
		barrierPoints.Add (bottom);


		//TODO:
//		//construct points that are angled
//		for (int i = 15; i < 90; i = i + 15) {
//			Vector3 angle = new Vector3 (0, i, 0);
//			barrierPoints.Add (RotatePointAroundPivot (left, center, angle));
//			barrierPoints.Add (RotatePointAroundPivot (right, center, angle));
//			barrierPoints.Add (RotatePointAroundPivot (top, center, angle));
//			barrierPoints.Add (RotatePointAroundPivot (bottom, center, angle));
//		}

		attackBarrier = new Bounds (center, new Vector3(firingRange * 2, 0, firingRange * 2));
	}

	void Maneuver() {
		float distanceTemp = 1000;
		Vector3 attackPossibility = new Vector3 ();
		for (int i = 0; i < barrierPoints.Count; i++) {
			Vector3 possible = (Vector3) barrierPoints[i];
			//print ("Possibility:  " + Vector3.Distance (transform.position, possible) + "\t" + distanceTemp + "\t" + attackDistance);
			if (Vector3.Distance (transform.position, possible) < distanceTemp)  {
				attackPossibility = possible;
				distanceTemp = Vector3.Distance (transform.position, possible);
			}
		}

		if (attackPosition == null || distanceTemp < attackDistance) {
			attackPosition = attackPossibility;
			attackDistance = distanceTemp;
		} 
		//print ("travel to " + attackPosition +"\t" + attackPossibility + "\t" + transform.position + "\t" + player.transform.position);
		Move (transform.position, attackPosition, attackSpeed);
	}

	void ClearAttack() {
		attackDistance = 1000;
		barrierPoints.Clear ();
		attackBarrier = new Bounds ();
		//distanceToDestination = 0;
	}

	void Attacking() {
		state = ATTACK;
		if (barrierPoints.Count == 0 || attackBarrier == null || !attackBarrier.Contains (player.transform.position)) {
			ConstructBarrier ();
		} else if (attackDistance == 0) {
			//print ("RESET");
			barrierPoints.Remove(attackPosition);
			attackDistance = 1000;
			Maneuver();
		}else {
			Maneuver();
		}
	}

	void Chasing() {
		state = CHASE;
		ClearAttack ();
		Move (transform.position, player.transform.position, chaseSpeed);
	}
	
	void Patrolling ()
	{
		state = PATROL;
		ClearAttack ();

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

		Move (transform.position, wayPoint.position, patrolSpeed);
	}
	
	void Move(Vector3 current, Vector3 destination, float speed) {
		//print ("Move: " + current + "\tto " + destination);
		if (destination - current != Vector3.zero) {
			Quaternion rotation = Quaternion.LookRotation(destination - current);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
		}

		distanceToDestination = Vector3.Distance (current, destination);
		transform.position = Vector3.MoveTowards(current, destination, speed * Time.deltaTime);
	}
}
