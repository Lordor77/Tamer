using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonster : MonoBehaviour {
    [SerializeField]
    public Stat health;

    // Use this for initialization
    private void Awake()
    {
        health.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //health.CurrentVal -= 10;
    }
}
