using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

	private int currentLevelIndex;
	private string[] _tipTable = {"Someone seems hungry", 
		"This city looks a bit haunted", 
		"Bunnies are such surprising creatures", 
		"These mushrooms don't look edible",
		"Cactuses don't seem safe"
		};
	
	[SerializeField] private float levelLoadDelay = 3f;
	[SerializeField] private float tipShowTime = 3f;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject _canvasGameplay;
	[SerializeField] private GameObject _canvasSuccess;
	[SerializeField] private GameObject _canvasStart;
	[SerializeField] private GameObject _canvasFail;
	[SerializeField] private Text _tipTxt;
	
	[SerializeField] private AudioClip lostLifeSFX;

	void Awake()
	{
		int numGameSessions = FindObjectsOfType<GameSession>().Length;
		if (numGameSessions > 1) Destroy(gameObject);
		else DontDestroyOnLoad(gameObject);
		
	}
	
	void Start ()
	{
		currentLevelIndex = GameObject.FindGameObjectsWithTag("Level").Length - 1;
	}

//	public void ProcessPlayerDeath()
//	{
//		ProcessFail();
//	}

//	private void PrepareTowerMode()
//	{
//		
//	}

	public void DisposeCurrentLevel()
	{
		string name = "Level_" + currentLevelIndex.ToString();
		if (GameObject.Find(name).scene.IsValid())
		{
			if (currentLevelIndex == 0) ProcessWin();
			Destroy(GameObject.Find(name).gameObject);
			currentLevelIndex--;
			StartCoroutine(ShowTip(_tipTable[currentLevelIndex-1]));
			Debug.Log("___ " + name + " has been destroyed.");
			GameObject lowerLevel = GameObject.Find("Level_" + (currentLevelIndex).ToString()).gameObject;
			Transform lowerLevelTransform = lowerLevel.transform;
			foreach (Transform child in lowerLevelTransform) 
				if (child.name == "Landscape") 
					child.gameObject.SetActive(true);
			Transform[] children = lowerLevel.transform.GetComponentsInChildren<Transform>();
			foreach (var child in children) {
				if (child.name == "Ceil")
					child.gameObject.SetActive(true);
			}
		}
	}
	
	IEnumerator PrepareNextLevel(GameObject child)
	{
		child.SetActive(true);
		yield return new WaitForSecondsRealtime(levelLoadDelay);
	}

	IEnumerator LoadPlayer(GameObject player)
	{
		yield return new WaitForSecondsRealtime(levelLoadDelay);
		player.SetActive(true);
		Debug.Log("___Set Active_________________");
	}

	IEnumerator ShowTip(string tip)
	{
		_tipTxt.text = tip;
		_tipTxt.enabled = true;
		yield return new WaitForSecondsRealtime(tipShowTime);
		_tipTxt.enabled = false;
	}

	public void ReloadScene()
	{
		Debug.Log("___ " + "Scene reloaded.");
		_canvasSuccess.SetActive(false);
		_canvasFail.SetActive(false);
		_canvasStart.SetActive(false);
		_canvasGameplay.SetActive(false);
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);;
	}

	public void StartGame()
	{
//		PrepareTowerMode();
		_canvasStart.SetActive(false);
		_canvasGameplay.SetActive(true);
		StartCoroutine(ShowTip(_tipTable[currentLevelIndex-1]));
		StartCoroutine(LoadPlayer(player));
	}

	public void ProcessWin()
	{
		player.SetActive(false);
		_canvasGameplay.SetActive(false);
		_canvasSuccess.SetActive(true);
	}

	public void ProcessFail()
	{
		AudioSource.PlayClipAtPoint(lostLifeSFX, Camera.main.transform.position);
		player.SetActive(false);
		_canvasGameplay.SetActive(false);
		_canvasFail.SetActive(true);
	}
}
