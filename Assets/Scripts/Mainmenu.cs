using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    private void Start() {
        Application.targetFrameRate = 60;
    }
    public void PlayGame() {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
