﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remanufacture_level : MonoBehaviour {

    [SerializeField]
    private Text timerChange;//Maybe use this to add some flavor?

    public Slider timer;//The visual representation of this timer, and with that the duration to be in game
    [SerializeField]
    private float timerCurrent = 1;
    private float currentTimer = 0;
    private float executeSpeed = 1; //time between executions
    public float subtractAmount = 0.1f; //The step the timer downgrades
    private bool endingCalled = false; // make sure to only call the ending of the level once

    //Setup level with the correct lines
    void Start() {
        GameManager.instance.episodeManager.ResetLines();
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode2);
        }
    //A simple timer
    void Update () {
        if (!endingCalled) {
            if (timerCurrent > 0) {
                if (currentTimer >= executeSpeed) {
                    //Do action
                    timerCurrent -= subtractAmount;
                    currentTimer = 0;
                    timer.value = Mathf.Clamp(timerCurrent, 0, 1);
                    }
                else {
                    currentTimer += Time.deltaTime;
                    timer.value = Mathf.Clamp(timerCurrent, 0, 1);
                    }
                }
            else {
                //level done
                StartCoroutine(GameManager.instance.episodeManager.EndCurrentEpisode());
                Debug.Log("called ending");
                endingCalled = true;
                }
            }

        }

    //Function to add time to extend the longelivety of this level
    public float AddToTimer(float amount) {
        timerCurrent += amount;
        return timerCurrent;
        }
    }
/*
1 is de max (1.00F)
timer moet dus als max value 1.00F hebben
Stel 60 seconde
1/60 = de stapwaarde(?)
*/