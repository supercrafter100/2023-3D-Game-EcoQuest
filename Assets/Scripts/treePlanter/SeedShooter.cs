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
            if (Input.GetKey(KeyCode.Mouse0) && !handled && game.seeds > 0)
            {
                Vector3 spawnPosition = transform.position + transform.forward + (Vector3.up * 1.6f);
                GameObject obj = Instantiate(seedObject, spawnPosition, gameObject.transform.rotation);
                obj.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);
                obj.GetComponent<SeedToTree>().gameManager = game;
                audio.Play();
                game.seeds--;
                handled = true;
            }
            else
            {
                handled = false;
            }
        }
    }    
}

