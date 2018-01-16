using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class PlayerSetup : MonoBehaviour
{

    [SerializeField]
    Behaviour[] componentsToDisable;
    Camera sceneCamera;

    void Start()
    {
       
        
            DisableTheComponents();
          //  AssigningRemoteLayer();                
           // sceneCamera = Camera.main;
          //  if (sceneCamera != null)
          //  {
          //      sceneCamera.gameObject.SetActive(false);
         //   }
        
        
    }
    //Not relevant for this stage in the game
  //  void OnDisable()
   // {
     //   if (sceneCamera != null)
     //   {
     //       sceneCamera.gameObject.SetActive(true);
     //   }
   // }

    void DisableTheComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }
    //Not relevant for this stage in the game
    void AssigningRemoteLayer()
    {
        gameObject.layer = 9;
    }
}
