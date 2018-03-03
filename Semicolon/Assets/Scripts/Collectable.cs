﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    [SerializeField]
    GameObject Player;
    private bool bIsCollected;
    Vector2 tempPos = new Vector2();
    public float hoverAmplitude = 0.5f;
    public float hoverFrequency = 1f;


    // Use this for initialization
    void Start () {
        bIsCollected = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (bIsCollected)
        {
            Destroy(gameObject,.1f);
        }
        tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * hoverFrequency) * hoverAmplitude;
        transform.position = tempPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!bIsCollected)
        {
            bIsCollected = true;
            Player.GetComponent<PlayerPlatformerController>().SendMessage("getCollectable");
        }
    }
}