using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] public int levelNumber;
    [SerializeField] public Text levelTime;
    [SerializeField] public int time;
    [SerializeField] public Text highScore;


    //Timer for level; time bonus and time marker
    private void Start()
    {
        time = (int) Time.time;
        levelTime.text = (Time.time - time).ToString();
        highScore.text = 0.ToString();
        
    }

    private void Update()
    {
        levelTime.text = ( (int) (Time.time - time)).ToString();
        
        //Time max
        if((int)(Time.time - time) >= 999)
        {
            levelTime.text = "999";
        }

        highScore.text = FindObjectOfType<GameSession>().Level_highScore[levelNumber].ToString();
    }
}
