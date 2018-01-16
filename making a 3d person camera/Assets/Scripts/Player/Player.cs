using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Variables
    [SerializeField]
    public Stat health;
    [SerializeField]
    public Stat energy;
    bool energyNeedRegen;
    float energyRegenTimer;

    [SerializeField]
    public GameObject enemyMonsterCam;


    // Use this for initialization
    private void Awake ()
    {
        health.Initialize();
        energy.Initialize();

        energyNeedRegen = false;
        energyRegenTimer = 1;
    }

    // Update is called once per frame
    void Update () {
        // Energy Regeneration shit
        if (this.gameObject.GetComponent<Player>().energy.CurrentVal < 100)
            energyNeedRegen = true;
        else
        {
            energyNeedRegen = false;
            energyRegenTimer = 1;
        }

        if (energyNeedRegen)
            energyRegenTimer -= Time.deltaTime;

        if (energyRegenTimer <= 0)
        {
            this.gameObject.GetComponent<Player>().energy.CurrentVal += 1;
            energyRegenTimer = 1;
        }

        // Capture the enemy monster
        if (Input.GetKeyDown(KeyCode.X))
        {
            enemyMonsterCam.SetActive(true);
        }


        /* TESTING
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.CurrentVal -= 10;
            energy.CurrentVal -= 10;
        }
        */
    }
}
