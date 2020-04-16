using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] public int levelNumber;
    [SerializeField] public Text levelTime;
    [SerializeField] public float time;


    //Timer for level; time bonus and time marker
    private void Start()
    {
        time = Time.time;
        levelTime.text = (Time.time - time).ToString("0F");
    }

    private void Update()
    {
        levelTime.text = (Time.time - time).ToString("0F");
    }
}
