using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;

namespace level_hub
{
    public class CutsceneBehavior : MonoBehaviour
    {
        public GameObject playerCamera;
        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.GetInt("hub_cutscene") == 1)
            {
                playerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            }
            else
            {
                PlayerPrefs.SetInt("hub_cutscene", 1);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }   
}
