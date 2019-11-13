using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionHandler : MonoBehaviour
{
    public GameObject timerObject;
    private Timer timerScript;
    // Start is called before the first frame update
    void Start()
    {
        if (timerObject != null)
            timerScript = timerObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") || other.gameObject.name.Equals("Kart"))
        {
            if(timerScript != null)
                timerScript.SaveToJsonLocalFile();

            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }
}
