using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourBall : MonoBehaviour {
	
	[SerializeField] private GameObject attractedTo;
	[SerializeField] private GameObject spawnPoint;
	[SerializeField] private GameObject floor;
	[SerializeField] private float strengthOfAttraction;

	//private bool isAlive = true;
	private SphereCollider _sphereCollider;

	void Start()
	{
		_sphereCollider = GetComponent<SphereCollider>();
	}
	
	void Update()
	{
		Attraction();
		DieOfHeight();
	}

	void Attraction()
	{
		Vector3 direction = attractedTo.transform.position - transform.position;
		GetComponent<Rigidbody>().AddForce(strengthOfAttraction * direction);
	}
	
	void DieOfHeight()
	{
		if(transform.position.y < floor.transform.position.y - 10)
		{
			transform.position = spawnPoint.transform.position;
			FindObjectOfType<GameSession>().ReloadScene();
		}
//		if (_sphereCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
//		{
//			isAlive = false;
////			myAnimator.SetTrigger("Dying");
////			GetComponent<Rigidbody2D>().velocity = deathKick;
//			FindObjectOfType<GameSession>().ProcessPlayerDeath();
//		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("Hazards") ||
		    collision.gameObject.layer == LayerMask.NameToLayer("Mob"))
		{
			FindObjectOfType<GameSession>().ProcessFail();
		}
	}
}
