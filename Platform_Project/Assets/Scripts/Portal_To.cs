using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_To : MonoBehaviour
{
    //Scene to teleport toward
    [SerializeField] int levelPortal;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.GetComponent<PlayerMotion>() && Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene(levelPortal);
        }
    }
}
