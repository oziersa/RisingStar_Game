using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] float levelLoad = 2f;

    //Cached references
    int levelNumber;

    private void Start()
    {
        levelNumber = FindObjectOfType<LevelInfo>().levelNumber;
    }

    // Initiate to the next level on player collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        if(other.GetComponent<PlayerMotion>())
        {
            Debug.Log("Correct");
            StartCoroutine(loadNextScene());
        }
    }

    IEnumerator loadNextScene()
    {
        //Insert transition before moving scenes
        //TBD

        GameSession session = FindObjectOfType<GameSession>();

        //New High Score
        if(session.levelScore > session.Level_highScore[levelNumber])
        {
            session.Level_highScore[levelNumber] = session.levelScore;

            //Update Player Score
            session.playerScore = 0;

            foreach( int score in session.Level_highScore)
            {
                session.playerScore += score;
            }
        }

        //Level Cleared; Reset Score to prevent point grinding
        session.Level_clear[levelNumber] = true;
        session.levelScore = 0;
        session.scoreText.text = session.levelScore.ToString();

        yield return new WaitForSeconds(levelLoad);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
