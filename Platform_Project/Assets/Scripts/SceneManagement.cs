using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] public PausedMenu menuUI;


    public void StartGame()
    {
        Debug.Log("Trying");
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MoveToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !menuUI.gamePaused && SceneManager.GetActiveScene().buildIndex > 0)
        {
            menuUI.Pause();

        }
    }
}
