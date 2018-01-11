﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    public Stat health;

	// Use this for initialization
	private void Awake ()
    {
        health.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.CurrentVal -= 10;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            health.CurrentVal += 10;
        }
    }
}
