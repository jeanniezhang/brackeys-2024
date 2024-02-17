using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChanger : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            print("switching scene to " + sceneName);
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
