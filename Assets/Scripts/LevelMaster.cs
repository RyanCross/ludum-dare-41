using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LevelMaster : MonoBehaviour {

    public AudioMixer audioMixer;

    // Use this for initialization
    void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("SliderVolumeLevel"));
    }
}
