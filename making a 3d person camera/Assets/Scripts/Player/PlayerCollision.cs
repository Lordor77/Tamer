using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    // Checks if there is a collision between the Player and a EnemyMonster
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "EnemyMonster")
        {
            if (this.GetComponent<Rigidbody>().velocity.magnitude > collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude)
            {
                collision.gameObject.GetComponent<EnemyMonster>().EnemyHealth.CurrentVal -= 10;
                if (collision.gameObject.GetComponent<EnemyMonster>().EnemyHealth.CurrentVal <= 0)
                {
                    Destroy(collision.gameObject);
                    SceneManager.LoadScene("BasicScene");
                }
            }
            else
            {
                this.gameObject.GetComponent<Player>().health.CurrentVal -= 10;
                if (this.gameObject.GetComponent<Player>().health.CurrentVal <= 0)
                {
                    Destroy(this.gameObject);
                    SceneManager.LoadScene("BasicScene");
                }
            }


            this.GetComponent<Rigidbody>().AddForce(transform.forward * -15, ForceMode.Impulse);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.gameObject.transform.forward * -15, ForceMode.Impulse);
        }
    }

    /* // TESTING:
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyMonster"))
        {
            this.GetComponent<Rigidbody>().AddForce(transform.forward * -10, ForceMode.Impulse);
            other.GetComponent<Rigidbody>().AddForce(other.transform.forward * -10, ForceMode.Impulse);
        }
    }
    */
}
