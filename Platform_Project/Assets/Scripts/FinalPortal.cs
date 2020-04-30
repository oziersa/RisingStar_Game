using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPortal : MonoBehaviour
{
    //Scene to teleport toward; used in OverWorld
    [SerializeField] int levelPortal;
    [SerializeField] int levelRequirement;
    [SerializeField] int followReq;

    //Cached reference
    GameSession session;

    private void Start()
    {
        session = FindObjectOfType<GameSession>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Requirements to use portal
        if (collision.GetComponent<PlayerMotion>() && Input.GetButton("Fire1") && session.Level_clear[levelRequirement] && session.playerScore >= followReq)
        {
            SceneManager.LoadScene(levelPortal);
        }

        //Required level not cleared
        else if (collision.GetComponent<PlayerMotion>() && Input.GetButton("Fire1"))
        {
            Debug.Log("Requires: " + levelRequirement);
        }
    }

    private void Update()
    {
        session = FindObjectOfType<GameSession>();
    }

}
