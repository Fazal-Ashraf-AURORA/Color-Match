using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [Header("Game Objects to spawn")]
    [SerializeField] GameObject circle;
    [SerializeField] GameObject sqaure;

    [Header("Trigger to check the collision of spawned game objects")]
    [SerializeField] GameObject triggerCheck;

    [Header("Reference of the Player")]
    [SerializeField] GameObject player;

    [Header("Reference of Tutorial Text")]
    [SerializeField] TextMeshProUGUI tutorialText;

    public static bool tutorialShown = false;
    public int tutorialStage;

    void Start() {
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial() {
        player.GetComponent<TutorialColorSwitch>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        tutorialText.text = "Tap the disk below to switch it's color.";
        player.GetComponent<TutorialColorSwitch>().enabled = true;
        Time.timeScale = 0;

        yield return new WaitForSeconds(1f);
        tutorialText.text = "";
        player.GetComponent<TutorialColorSwitch>().enabled = false;

        yield return new WaitForSeconds(1f);
        circle.SetActive(true);

        yield return new WaitForSeconds(1f);
        player.GetComponent<TutorialColorSwitch>().enabled = true;
        tutorialText.text = "Collect the circle with same disk color.";
        Time.timeScale = 0;

        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        tutorialText.text = "";

        yield return new WaitForSeconds(2f);
        sqaure.SetActive(true);

        yield return new WaitForSeconds(1f);
        player.GetComponent<TutorialColorSwitch>().enabled = true;
        tutorialText.text = "Collect the square with opposite disk color.";
        Time.timeScale = 0;

        yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
        tutorialText.text = "";

        yield return new WaitForSeconds(1f);
        tutorialText.text = "Tap the disk to continue.";
        Time.timeScale = 0;

        yield return new WaitForSeconds(0.3f);
        
        SceneManager.LoadScene("Gameplay");
    }

}

