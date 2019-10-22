using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD

=======
>>>>>>> b5487cebdee1f97c8d8bec6f1b2e77a7929b51aa
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

<<<<<<< HEAD
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
=======
    public void QuitGame() {
        Application.Quit();
    }

    
}

>>>>>>> b5487cebdee1f97c8d8bec6f1b2e77a7929b51aa
