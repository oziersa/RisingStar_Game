using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelPearl : MonoBehaviour
{
    [SerializeField] AudioClip confirmation;
    [SerializeField] int pearlScore = 500;
    [SerializeField] bool touched = false;
    [SerializeField] int pearlCount;

    //Pearl touch
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CapsuleCollider2D>() && !touched)
        {
            touched = true;
            AudioSource.PlayClipAtPoint(confirmation, transform.position);
            FindObjectOfType<GameSession>().AddScore(pearlScore);
            FindObjectOfType<PearlGate>().pearlyGate -= 1;
            Destroy(gameObject);
        }
    }
}
