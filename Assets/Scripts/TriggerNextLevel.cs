using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextLevel : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameSession>().DisposeCurrentLevel();
    }
}
