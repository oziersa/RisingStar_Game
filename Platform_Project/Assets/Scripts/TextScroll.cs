using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] public Image blackOut;

    private void Start()
    {
        anim.SetBool("End", false);
    }

    private void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y + 1f, gameObject.transform.position.z);

        if(gameObject.transform.position.y > 700)
        {
            Debug.Log("Over");
            StartCoroutine(sceneFade());
        }
    }

    IEnumerator sceneFade()
    {
        //Make transition
        anim.SetBool("End", true);

        yield return new WaitUntil(() => blackOut.color.a == 1f);

        SceneManager.LoadScene(0);
    }
}
