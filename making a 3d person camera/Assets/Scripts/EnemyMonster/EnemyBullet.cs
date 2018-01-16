using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BuddyMonster"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>().health.CurrentVal -= 10;
            if (other.gameObject.GetComponent<Player>().health.CurrentVal <= 0)
                SceneManager.LoadScene("BasicScene");
        }
    }
}
