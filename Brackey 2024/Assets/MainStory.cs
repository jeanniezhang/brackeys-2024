using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    void OnEnable() {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
