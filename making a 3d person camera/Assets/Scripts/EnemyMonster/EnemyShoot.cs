using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    // Variables
    [SerializeField]
    GameObject Bullet;
    float attTimer_1;
    float attTimer_2;


    // Use this for initialization
    void Start()
    {
        attTimer_1 = Random.Range(1, 4);
        attTimer_2 = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        attTimer_1 -= Time.deltaTime;
        attTimer_2 -= Time.deltaTime;

        if (attTimer_1 <= 0)
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(Bullet, this.transform.position, this.transform.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 26;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 20.0f);

            attTimer_1 = Random.Range(1, 3);
        }

        //* //// Dor: for testing a second ability.
        if (attTimer_2 <= 0)
        {
            // Jumps forward, dealing damage to whatever this object hits
            this.GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
            this.GetComponent<Rigidbody>().AddForce(transform.forward * 16, ForceMode.Impulse);

            attTimer_2 = Random.Range(4, 8);
        }
        //*/
    }
}
