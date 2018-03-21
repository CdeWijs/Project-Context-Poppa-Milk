﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle_level : MonoBehaviour, ILevel {

    // Use this for initialization
    [SerializeField]
    private float timerDuration = 1;
    [SerializeField]
    private float subtractAmount = 0.03f; //The step the timer downgrades
    [SerializeField]
    private bool hasTimer = true;
    //Setup level with the correct lines
    void Start() {

        GameManager.instance.levelTimer.SetupTimer(timerDuration, subtractAmount, hasTimer);
        GameManager.instance.levelTimer.currentLevel = this.gameObject;
        StartCoroutine(LevelDialogues());
        }
    // Update is called once per frame
    void Update () {
		
	}
    public IEnumerator LevelDialogues() {
        yield return new WaitForSeconds(2);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        yield return new WaitForSeconds(5);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        yield return new WaitForSeconds(5);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        yield return new WaitForSeconds(5);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        yield return new WaitForSeconds(5);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        yield return new WaitForSeconds(5);
        }
    public IEnumerator EndLevelSequence() {
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        yield return new WaitForSeconds(5);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        StartCoroutine(GameManager.instance.episodeManager.EndCurrentEpisode());
        }
    }