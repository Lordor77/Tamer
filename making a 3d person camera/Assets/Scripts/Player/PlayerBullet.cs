using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyMonster"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<EnemyMonster>().EnemyHealth.CurrentVal -= 10;
            if (other.gameObject.GetComponent<EnemyMonster>().EnemyHealth.CurrentVal <= 0)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene("BasicScene");
            }
        }
    }
}
