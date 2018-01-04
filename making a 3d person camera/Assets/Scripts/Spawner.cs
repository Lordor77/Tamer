using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Monster;
    private float RepeatTime = 3f;
    int i = 0;

    void Start()
    {
        InvokeRepeating("Spawn", 2f, RepeatTime);
    }

    void Spawn()
    {
        if (i < 5)
        {
            Instantiate(Monster, transform.position, Quaternion.identity);
            i++;
        }
    }

}