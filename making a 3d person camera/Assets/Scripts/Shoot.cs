using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // Variables
    float timer;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Player;

	// Use this for initialization
	void Start () {
		timer = Random.Range(1, 4);
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        transform.LookAt(Player.transform);

        if (timer <= 0) {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 12;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 20.0f);

            timer = Random.Range(1, 4);
        }
	}
}
