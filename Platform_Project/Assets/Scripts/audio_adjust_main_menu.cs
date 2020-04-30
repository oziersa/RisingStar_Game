using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audio_adjust_main_menu : MonoBehaviour
{
    public AudioMixer audioMixer;
   public void SetVolume(float volume)
    {
       audioMixer.SetFloat("volume", volume);

    }
}
