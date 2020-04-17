using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelFan : MonoBehaviour
{
    [SerializeField] AudioClip fanNoise;
    [SerializeField] int fanScore = 100;


    //Fan interaction
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if(playerCollider.GetComponent<PlayerMotion>())
        {
            Destroy(GetComponent<BoxCollider2D>());
            AudioSource.PlayClipAtPoint(fanNoise, transform.position);
            FindObjectOfType<GameSession>().AddScore(fanScore);
        }
    }
}
