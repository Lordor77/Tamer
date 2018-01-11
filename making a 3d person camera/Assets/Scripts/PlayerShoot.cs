using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    // Variables
    [SerializeField]
    GameObject Bullet;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E)) {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 12;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 20.0f);
        }
	}
}
