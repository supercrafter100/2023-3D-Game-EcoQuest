using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace treePlanter
{
    public class GameManager : MonoBehaviour
    {
        public TMP_Text treesTextElement;
        public TMP_Text seedsTextElement;

        public int seeds = 0;
        public int trees = 0;

        public int treesGoal = 20;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            treesTextElement.SetText("Bomen geplant: " + trees + " / " + treesGoal);
            seedsTextElement.SetText("Zaden: " + seeds);
        }
    }    
}

