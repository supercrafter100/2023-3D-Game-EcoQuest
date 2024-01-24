using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace treePlanter
{
    public class SeedSpawner : MonoBehaviour
    {
        public Vector3 pos1;
        public Vector3 pos2;
        public GameObject seedGameObject;
        public int seeds = 500;

        private readonly Random _r = new Random();

        private void Awake()
        {
            RaycastHit hit;

            for (int i = 0; i < seeds; i++)
            {
                Vector3 position = new Vector3(_r.Next((int)pos1.x, (int)pos2.x), 0, _r.Next((int)pos1.z, (int)pos2.z));
                if (Physics.Raycast(position + new Vector3(0, 100f, 0), Vector3.down, out hit, 500f))
                {
                    Instantiate(seedGameObject, hit.point, Quaternion.identity);
                }
            }
        }
    }   
}
