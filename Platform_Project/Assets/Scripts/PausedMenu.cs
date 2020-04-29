using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausedMenu : MonoBehaviour
{

    //Game state progression
    [SerializeField] public bool gamePaused = false;

    //Game object
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] Text followerCount;

    //Cached references
    float followCount;

    // Start is called before the first frame update
    void Start()
    {
        //Keeping up with the Kardashians
        followCount = FindObjectOfType<GameSession>().playerScore;
        followerCount.text = followCount.ToString();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //Menu active or not

        if(Input.GetKeyDown(KeyCode.M))
        {
            if (gamePaused)
            {
                Resume();
            }

            else
            {
                Pause();  
            }
        }
        
    }


    //Public methods for additional uses
    public void Resume()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void MenuMove()
    {
        pauseUI.SetActive(false);
    }
}
