using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Variables
    [SerializeField]
    public Stat health;
    [SerializeField]
    public Stat energy;
    
    bool isEnergyRegenTimer;
    float energyRegenTimer;

    [SerializeField]
    public GameObject enemyMonster;
    [SerializeField]
    public GameObject enemyMonsterCam;

    bool isCaptureTimer;
    float captureTimer;
    int rand;


    // Use this for initialization
    private void Awake ()
    {
        health.Initialize();
        energy.Initialize();

        isEnergyRegenTimer = false;
        energyRegenTimer = 1f;

        isCaptureTimer = false;
        captureTimer = 6f;
        rand = -999;
    }

    // Update is called once per frame
    void Update () {
        // Energy Regeneration shit
        if (this.gameObject.GetComponent<Player>().energy.CurrentVal < 100)
            isEnergyRegenTimer = true;
        else
        {
            isEnergyRegenTimer = false;
            energyRegenTimer = 1;
        }

        if (isEnergyRegenTimer)
            energyRegenTimer -= Time.deltaTime;

        if (energyRegenTimer <= 0)
        {
            this.gameObject.GetComponent<Player>().energy.CurrentVal += 1;
            energyRegenTimer = 1;
        }

        // Capture the enemy monster
        if (isCaptureTimer) 
            captureTimer -= Time.deltaTime;

        if (enemyMonster.GetComponent<MeshRenderer>().enabled && rand == -999 && captureTimer <= 4f)
            enemyMonster.GetComponent<MeshRenderer>().enabled = false;

        if (!enemyMonster.GetComponent<MeshRenderer>().enabled && rand == -999 && captureTimer <= 2f)
        {
            rand = Random.Range(1, 5);
            if (rand != 4) // Didn't capture it... :/
                enemyMonster.GetComponent<MeshRenderer>().enabled = true;
        }

        if (captureTimer <= 0)
        {
            if (!enemyMonster.GetComponent<MeshRenderer>().enabled)
                Destroy(enemyMonster.gameObject); // It had been captured !!! Yay !!!!!

            captureTimer = 6f;

            enemyMonsterCam.SetActive(false);
            enemyMonster.GetComponent<EnemyShoot>().enabled = true;
            this.GetComponent<MonsterController>().enabled = true;
            this.GetComponent<PlayerShoot>().enabled = true;
            isCaptureTimer = false;
            rand = -999;
        }

        if (Input.GetKeyDown(KeyCode.X) && !isCaptureTimer)
        {
            enemyMonsterCam.SetActive(true);
            enemyMonster.GetComponent<EnemyShoot>().enabled = false;
            this.GetComponent<MonsterController>().enabled = false;
            this.GetComponent<PlayerShoot>().enabled = false;
            isCaptureTimer = true;
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
