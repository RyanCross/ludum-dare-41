﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelMaster : MonoBehaviour {

    public AudioMixer audioMixer;
    public Enemy commander;
    public Canvas shop;
    public WaveSpawner waveSpawner;

    // Use this for initialization
    void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("SliderVolumeLevel"));
    }

    void Update()
    {
        if (Enemy.zombieEstimate<=0 && GameObject.FindGameObjectsWithTag("Enemy").Length==1)
        {
            if (shop.gameObject.activeSelf == false)
            {        
                shop.gameObject.SetActive(true);
                if (WaveSpawner.waveNum == 2)
                {
                    SceneManager.LoadScene(3);
                }
            }
        }
    }
}
