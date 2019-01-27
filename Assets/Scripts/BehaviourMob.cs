using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourMob : MonoBehaviour {

	[SerializeField] private float moveSpeed = 0.05f;
	private Rigidbody _rigidbody;
	
	// Use this for initialization
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (IsFacingForward())
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		else
			transform.Translate(Vector3.forward * (-moveSpeed) * Time.deltaTime);
	}

	bool IsFacingForward()
	{
		return transform.localScale.z > 0;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(IsFacingForward())
			transform.localScale = new Vector3(2f, 2f, -2f);
		else
			transform.localScale = new Vector3(2f,2f,2f);
//		if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
//			FindObjectOfType<GameSession>().ProcessFail();
	}
}
