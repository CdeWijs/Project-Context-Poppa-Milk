﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public EpisodeManager episodeManager;
    public AudioManager audioManager;
    public GameObject poppaMilk;

    public void Awake() {
        if(instance == null) {
            instance = this.gameObject.GetComponent<GameManager>();
        }else {
            Debug.Log("A game manager already exists");
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

	void Start () {
        //Call all start functions from the components
        this.episodeManager = this.GetComponent<EpisodeManager>();
        this.audioManager = this.GetComponent<AudioManager>();
        episodeManager.EpisodeInit();
        audioManager.AudioInit();
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Presentation);

        //episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        //episodeManager.NewEpisode(1);
        }
}
