using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelFan : MonoBehaviour
{
    [SerializeField] AudioClip fanNoise;
    [SerializeField] int fanScore = 100;
    [SerializeField] bool notTouched = true;
    [SerializeField] Animator anim;


    //Fan interaction
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if(playerCollider.GetComponent<CapsuleCollider2D>() && notTouched)
        {
            anim.SetBool("Touched", true);
            notTouched = false;
            Destroy(GetComponent<BoxCollider2D>());
            AudioSource.PlayClipAtPoint(fanNoise, transform.position);
            FindObjectOfType<GameSession>().AddScore(fanScore);
        }
    }
}
