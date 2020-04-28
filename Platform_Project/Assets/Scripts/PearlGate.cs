using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlGate : MonoBehaviour
{
    //Pearls to catch
    [SerializeField] public int pearlyGate;
    [SerializeField] AudioClip door;

    // Update is called once per frame; Destroy when pearls are found
    void Update()
    {
        if(pearlyGate <= 0)
        {
            AudioSource.PlayClipAtPoint(door, gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
