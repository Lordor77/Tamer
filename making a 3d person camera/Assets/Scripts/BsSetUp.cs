using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class BsSetUp : MonoBehaviour
{

    private SwitchScenes scene;
    private RandomMov mov;
    void Start()
    {
        scene = GetComponent<SwitchScenes>();
        mov = GetComponent<RandomMov>();

    }

    void Update()
    {
        scene.enabled = false;
        mov.enabled = false;
    }
   
}