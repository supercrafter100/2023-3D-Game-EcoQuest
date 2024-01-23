using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace treePlanter
{
    public class SeedShooter : MonoBehaviour
    {
        public GameManager game;
        public GameObject seedObject;
        public AudioSource audio;

        private bool handled = false;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && game.seeds > 0 && !handled)
            {
                // Calculate the position the seed should spawn at
                Vector3 spawnPosition = transform.position + transform.forward + (Vector3.up * 1.6f);
                
                // Create our seed
                GameObject obj = Instantiate(seedObject, spawnPosition, gameObject.transform.rotation);
                
                // Set the speed of the seed to make it "throw"
                obj.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);
                
                // Assign the game manager because this seemed to be undefined every now and then when I did this
                // in the prefab itself
                obj.GetComponent<SeedToTree>().gameManager = game;
                
                // Play the throw audio,
                audio.Play();
                game.seeds--;
                handled = true;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                handled = false;
            }
        }
    }    
}

