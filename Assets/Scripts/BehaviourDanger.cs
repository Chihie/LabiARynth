using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class BehaviourDanger : MonoBehaviour
{

	[SerializeField] private float invokeDelay = 0.5f;
	private Material mat;//[] mats;
	private bool isRed = false;
	
	// Use this for initialization
	void Start () {
		mat = gameObject.GetComponent<MeshRenderer>().material;
//		mats = renderer.material;
		InvokeRepeating("Blink", 0, invokeDelay);
//		Material[] mats = gameObject.GetComponent.<Renderer>().materials;
//		mats[3] = mat2;
//		Part4.GetComponent.<Renderer>().materials = mats;
		
	}
	
	void Blink()
	{
		if (!isRed)
		{
			mat.color = Color.red;
//			gameObject.SetActive(false);
//			mats[0] = mats[1];
			
			isRed = true;
		}
		else
		{
			mat.color = Color.white;
//			gameObject.SetActive(true);
//			mats[0] = mats[2];
			isRed = false;
		}
	}
}


