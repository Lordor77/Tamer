﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterMovement : MonoBehaviour {

    // Variables
    [SerializeField]
    GameObject Player;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player.transform);
        //transform.Rotate(new Vector3(Player.transform.rotation.x, Player.transform.rotation.y, Player.transform.rotation.z));
    }
}
