using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour {

    private string scene = "BattleScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tamer"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
