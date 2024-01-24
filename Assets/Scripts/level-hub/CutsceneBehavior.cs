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
            if (SessionState.GetBool("hub_cutscene", false))
            {
                playerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 15;
            }
            else
            {
                SessionState.SetBool("hub_cutscene", true);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }   
}
