using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    IEnumerator waiter(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        
    }
    public void GoToScene(string sceneName) {
        StartCoroutine(waiter(sceneName));
        // SceneManager.LoadScene(sceneName);
        // WaitForSeconds(1);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}
