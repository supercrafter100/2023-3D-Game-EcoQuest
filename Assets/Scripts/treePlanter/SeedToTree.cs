using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace treePlanter
{
    public class SeedToTree : MonoBehaviour
    {
        public GameObject treePrefab;
        public GameManager gameManager;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionStay(Collision other)
        {
            CollisionHandler(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            CollisionHandler(other);
        }

        private void CollisionHandler(Collision other)
        {
            if (other.gameObject.name.StartsWith("Terrain"))
            {
                Destroy(gameObject);
                Instantiate(treePrefab, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
                gameManager.trees++;
            }
        }
    }
}

