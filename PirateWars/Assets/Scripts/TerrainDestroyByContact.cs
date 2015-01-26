using UnityEngine;
using System.Collections;

public class TerrainDestroyByContact : MonoBehaviour {

	public float bounce;
	void OnTriggerEnter(Collider other) 
	{
		//ignores ships
		if (other.tag == "Shot") 
		{
			Destroy (other.gameObject);
			return;
		} 
		else
			other.collider.rigidbody.velocity = new Vector3((-bounce)*other.collider.rigidbody.velocity.x, 0, (-bounce)*other.collider.rigidbody.velocity.z) ;
	}
}
