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
        public TMP_Text winnerTextElement;

        public int seeds = 0;
        public int trees = 0;

        public int treesGoal = 20;
    
        public bool isFinished => trees >= treesGoal;
        
        // Start is called before the first frame update
        void Start()
        {
            winnerTextElement.SetText("");
        }

        // Update is called once per frame
        void Update()
        {
            // Update ui elements
            treesTextElement.SetText("Bomen geplant: " + trees + " / " + treesGoal);
            seedsTextElement.SetText("Zaden: " + seeds);
            
            if (isFinished) winnerTextElement.SetText("Je hebt genoeg bomen geplant! Keer terug naar de hub via de teleporter bij je spawnlocatie");
        }
    }    
}

