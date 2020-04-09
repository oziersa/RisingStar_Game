using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    //Aspects of the game to hold onto for the duration of a game session-----------------------------
    [SerializeField] int playerScore = 0;
    [SerializeField] int playerHealth = 3;
    [SerializeField] int levelScore = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    //Logic for levels cleared; to enter the level portals
    [Header("Level clearance")]
    [SerializeField] bool[] Level_clear;
    


    //Awake function for a singleton effect----------------------------------------------------------
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        //Singleton logic
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    //Initialize the level
    private void Start()
    {
        livesText.text = playerHealth.ToString();
        scoreText.text = levelScore.ToString();
    }

    

    public void AddScore(int score)
    {
        levelScore += score;
        scoreText.text = levelScore.ToString();
    }

    //Process damage
    public void ProcessDamage()
    {
        if (playerHealth > 0)
        {
            playerHealth--;
            livesText.text = playerHealth.ToString();
            //TBD: alter health UI; invincibility frames
        }
        else
        {
            //TBD: process mortality
        }
    }

    //Load level score to player score upon completing the level
    public void updatePlayerScore(int score)
    {
        playerScore += score;
    }


    //---------------------------Options upon 'defeat'-----------------------

    //Reset level
    public void ResetLevel()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);
        levelScore = 0;
    }

    //Move to OverWorld
    public void BacktoOW()
    {
        //TBD: OverWorld scene; load it
        levelScore = 0;
    }

    //Move to MainMenu
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        levelScore = 0;
    }
}
