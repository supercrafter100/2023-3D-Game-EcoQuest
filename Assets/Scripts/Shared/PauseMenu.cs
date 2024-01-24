using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Shared
{
    public class PauseMenu : MonoBehaviour
    {
        public String scene;
        public Canvas canvas;
        public GameObject playerArmature;
        
        private bool isShowing = false;
        private bool debounce = false;
        
        // Start is called before the first frame update
        void Start()
        {
            playerArmature = GameObject.FindGameObjectWithTag("Player");
            canvas.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !debounce)
            {
                isShowing = !isShowing;
                debounce = true;
            } else if (Input.GetKeyUp(KeyCode.Escape) && debounce)
            {
                debounce = false;
            }
            
            canvas.gameObject.SetActive(isShowing);

            if (isShowing)
            {
                Time.timeScale = 0;
                AudioListener.pause = true;
                playerArmature.GetComponent<StarterAssetsInputs>().cursorLocked = false;
                playerArmature.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
                playerArmature.GetComponent<StarterAssetsInputs>().cursorLocked = true;
                playerArmature.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void Continue()
        {
            isShowing = false;
        }

        public void BackToHub()
        {               
            Time.timeScale = 1;
            AudioListener.pause = false;
            SceneManager.LoadScene(scene);
            isShowing = false;
        }

        public void ExitScene()
        {
            Application.Quit();
        }
    }
}

