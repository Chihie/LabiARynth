using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BehaviourDanger : MonoBehaviour
{

	[SerializeField] private float invokeDelay = 0.5f;
	private Material mat;
	private bool isRed = false;
	
	// Use this for initialization
	void Start () {
		mat = gameObject.GetComponent<MeshRenderer>().material;
		InvokeRepeating("Blink", 0, invokeDelay);		
	}
	
	void Blink()
	{
		if (!isRed)
		{
			mat.color = Color.red;			
			isRed = true;
		}
		else
		{
			mat.color = Color.white;
			isRed = false;
		}
	}
}


