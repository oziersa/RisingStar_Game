using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] AudioClip hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMotion>())
        {
            collision.GetComponent<PlayerMotion>().startPoint = gameObject;
            Destroy(GetComponent<Collider2D>());
            AudioSource.PlayClipAtPoint(hit, transform.position);
        }
    }
}
