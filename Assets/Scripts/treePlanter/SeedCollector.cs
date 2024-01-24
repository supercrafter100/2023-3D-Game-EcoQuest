using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace treePlanter
{
    public class SeedCollector : MonoBehaviour
    {
        public GameManager game;
        public AudioSource pickupAudio;
        public int pickupDistance = 3;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            // CollisionEnter and TriggerEnter didn't seem to work, hence this (rather inefficient) solution
            foreach (var seed in GameObject.FindGameObjectsWithTag("Seed"))
            {
                // Check if the distance between the player and the seed bag is less than 1
                if (Vector3.Distance(gameObject.transform.position, seed.transform.position) < pickupDistance)
                {
                    
                    // Destroy the seed element, add one to our total seeds and play the pickup audio sound
                    Destroy(seed);
                    game.seeds++;
                    pickupAudio.Play();
                }
            }
        }
    }
}
