using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Bullet : MonoBehaviour {

    // Use this for initialization
    private Player playerD;
    void Start()
    {
        playerD = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tamer"))
        {
            Destroy(gameObject);
            playerD.Damage();
        }
    }
}