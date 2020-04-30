using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class ExitLevel : MonoBehaviour
{
    //Time to wait b4 fade
    [SerializeField] float levelLoad = 0f;

    //Image to Fade
    [SerializeField] public Image blackOut;
    public Animator anim;

    //Cached references
    int levelNumber;

    private void Start()
    {
        levelNumber = FindObjectOfType<LevelInfo>().levelNumber;
        anim.SetBool("End", false);
    }

    // Initiate to the next level on player collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerMotion>())
        {
            StartCoroutine(sceneFade());
        }
    }

    IEnumerator loadNextScene()
    {
        //Insert transition before moving scenes
        //TBD

        GameSession session = FindObjectOfType<GameSession>();
        float time = FindObjectOfType<LevelInfo>().time;

        float addOn = 100f * (300f - (Time.time - time));
        session.levelScore += (int) Mathf.Max(0f, addOn);

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
        //lol
        SceneManager.LoadScene(2);
    }

    IEnumerator sceneFade()
    {
        //Make transition
        anim.SetBool("End", true);

        yield return new WaitUntil(()=>blackOut.color.a == 1f);

        StartCoroutine(loadNextScene());
    }
}
