using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour {
    private string sceneName;
    private string scene = "BattleScene";
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tamer") && sceneName != "BattleScene")
        {
            SceneManager.LoadScene(scene);
        }
    }
}
