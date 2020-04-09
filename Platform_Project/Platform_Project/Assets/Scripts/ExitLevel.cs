using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] float levelLoad = 2f;


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

        yield return new WaitForSeconds(levelLoad);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
