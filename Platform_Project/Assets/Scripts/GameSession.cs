using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    //Aspects of the game to hold onto for the duration of a game session-----------------------------
    [SerializeField] public int playerScore = 0;
    [SerializeField] public int levelScore = 0;

    [SerializeField] public Text scoreText;

    //Logic for levels cleared; to enter the level portals
    [Header("Level clearance")]
    [SerializeField] public bool[] Level_clear;
    [SerializeField] public int[] Level_highScore;


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
        scoreText.text = levelScore.ToString();
    }

    
    // In-level addition to score
    public void AddScore(int score)
    {
        levelScore += score;
        scoreText.text = levelScore.ToString();
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
