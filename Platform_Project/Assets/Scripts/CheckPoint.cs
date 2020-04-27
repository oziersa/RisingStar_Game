using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] AudioClip hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMotion>())
        {
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            collision.GetComponent<PlayerMotion>().startPoint = gameObject;
            AudioSource.PlayClipAtPoint(hit, transform.position);
        }
    }
}
