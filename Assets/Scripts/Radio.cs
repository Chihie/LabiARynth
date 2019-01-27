using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

	[SerializeField] private float musicVolumeScaleGameplay = 5.0F;
//	[SerializeField] private float musicVolumeScalePassings = 8.0F;
	private AudioSource standardMusic;
	
	private void Awake()
	{
		standardMusic = GetComponent<AudioSource>();
		standardMusic.volume = musicVolumeScaleGameplay;
		standardMusic.Play();
		int numRadio = FindObjectsOfType<Radio>().Length;
		if(numRadio > 1) Destroy(gameObject);
		else DontDestroyOnLoad(gameObject);
	}
 
	public void StopMusic()
	{
		standardMusic.Stop();
	}
}
