using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSetting : MonoBehaviour
{
    public Text volPercent;
    public AudioMixer mixer;
    public Slider Slider;

    //Cached
    int vol;

    public void SetVol (float sliderVolume)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderVolume)*20);
    }

    private void Update()
    {
        vol = (int) (Slider.value / Slider.maxValue * 100f);
        volPercent.text = vol.ToString() + " %";
    }
}
