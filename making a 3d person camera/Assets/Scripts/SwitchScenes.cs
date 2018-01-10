using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour {

    private string MoveToBS = "BattleScene";

    string sceneName;
    Collider some;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tamer") && sceneName == "BasicScene")
        {
            SceneManager.LoadScene(MoveToBS);
        }
    }
}
