using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeOption : MonoBehaviour
{
   

    //Cached references
    PausedMenu pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI = FindObjectOfType<PausedMenu>();
        gameObject.SetActive(false);
    }

    //Button interaction
    public void VolumeMenu()
    {
        gameObject.SetActive(true);
    }

    public void LeaveVolumeMenu()
    {
        gameObject.SetActive(false);
        pauseUI.Pause();
    }
}
