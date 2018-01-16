using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Variables
    [SerializeField]
    GameObject Bullet;
    float attackCoolDown;
    float energyCost;

    // Use this for initialization
    void Start () 
    {
        attackCoolDown = 0;
        energyCost = 10;

    }
	
	// Update is called once per frame
	void Update () 
    {
        if (attackCoolDown > 0)
            attackCoolDown -= Time.deltaTime;
        
		if (this.gameObject.GetComponent<Player>().energy.CurrentVal >= energyCost && Input.GetKeyDown(KeyCode.E) && attackCoolDown <= 0) {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 12;

            // Reducing the energy value
            this.gameObject.GetComponent<Player>().energy.CurrentVal -= energyCost;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 20.0f);

            // Resets this attack's cool down
            attackCoolDown = 2.5f;
        }
	}
}
