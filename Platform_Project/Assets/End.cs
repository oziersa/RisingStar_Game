using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMotion>())
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            FindObjectOfType<SceneManagement>().MoveToScene(index + 1);
        }
    }
}
