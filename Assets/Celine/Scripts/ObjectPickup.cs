﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour, IInteractable {
    public LayerMask layerMask;     // declare in inspector to "Object"

    [SerializeField]
    private bool clickable;
    [SerializeField]
    private int scoreAmount = 10;
    private PlayerController playerController;
    private InputSystem inputSystem;

    private Collider2D collision2D = null;
    private Animator animator;

    [SerializeField]
    private Transform targetPos;

    private void Start() {
        // Get player controller for player check, and input system for multiplatform use
        playerController = FindObjectOfType<PlayerController>();
        inputSystem = playerController.inputSystem;
        targetPos = GameObject.FindGameObjectWithTag("target").transform;
        Debug.Log(targetPos.position);
        collision2D = GetComponent<Collider2D>();
    }

    private void Update() {
        transform.parent.transform.position = transform.position;

    }

    public void OnClick() {
        if (clickable) {
            SetInActive();
        }
    }

    // Called from ObjectKillzone
    private void SetInActive() {
        GameManager.instance.scoreTracker.UpdateScore(scoreAmount);
        //transform.parent.gameObject.SetActive(false);
        transform.parent.transform.position = targetPos.position;
        GameManager.instance.scoreTracker.UpdateScore(scoreAmount);
    }

    public void SetRandom() {
        int random = Random.Range(0, 100);
        if (random < 40) {
            clickable = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red; // TEMP HACK
        }
        else {
            clickable = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white; // TEMP HACK
        }
        transform.parent.transform.localScale = new Vector3(Random.Range(1, 4), Random.Range(1, 4), transform.localScale.z);
    }
}