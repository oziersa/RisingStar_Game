using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void DestroyGameObject()
    {
        source.Play();
        Destroy(gameObject, 2.75f);
    }
}
