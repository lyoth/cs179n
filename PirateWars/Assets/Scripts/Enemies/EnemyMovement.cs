using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


	private GameObject player;							// Reference to the player.
	private NavMeshAgent nav;								// Reference to the nav mesh agent.
	public float patrolSpeed = 2f;							// The nav mesh agent's speed when patrolling.
	public float chaseSpeed = 5f;							// The nav mesh agent's speed when chasing.
	public float chaseWaitTime = 5f;						// The amount of time to wait when the last sighting is reached.
	public float patrolWaitTime = 1f;						// The amount of time to wait when the patrol way point is reached.
	private float chaseTimer;								// A timer for the chaseWaitTime.
	private float patrolTimer;								// A timer for the patrolWaitTime.
	public Transform[] patrolWayPoints;						// An array of transforms for the patrol route.
	private int wayPointIndex;								// A counter for the way point array.

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		wayPointIndex = 0;
	}

	void Awake() {
		player = GameObject.FindGameObjectWithTag(Tags.player);
		nav = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		Patrolling ();
	}

	void OnTriggerEnter(Collider other) {
		print ("OnTriggerEnter " + other.gameObject + "\t" + other);
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject == player) {
			print ("Player is in Arena!");
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		print ("OnTriggerExit");
	}

	void Patrolling ()
	{
		print("Patrolling: " + nav.speed + "\t" + patrolWayPoints.Length);
		// Set an appropriate speed for the NavMeshAgent.
		nav.speed = patrolSpeed;
		//nav.destination = patrolWayPoints [0].position;
//		
//		// If near the next waypoint or there is no destination...
//		if(nav.remainingDistance < nav.stoppingDistance)
//		{
//			// ... increment the timer.
//			patrolTimer += Time.deltaTime;
//			
//			// If the timer exceeds the wait time...
//			if(patrolTimer >= patrolWaitTime)
//			{
//				// ... increment the wayPointIndex.
//				if(wayPointIndex == patrolWayPoints.Length - 1)
//					wayPointIndex = 0;
//				else
//					wayPointIndex++;
//				
//				// Reset the timer.
//				patrolTimer = 0;
//			}
//		}
//		else
//			// If not near a destination, reset the timer.
//			patrolTimer = 0;
//		
//		// Set the destination to the patrolWayPoint.
//		nav.destination = patrolWayPoints[wayPointIndex].position;
	}

}
