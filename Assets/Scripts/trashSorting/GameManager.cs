using UnityEngine;
using UnityEngine.UI;

namespace trashSorting
{
    public class GameManager : MonoBehaviour
    {
        private int _score = 0;
        public Text scoreText;
        public Text message;

        private void Start()
        {
            scoreText.text = "Doel: vind en sorteer afval (" + _score + "/10)";
        }

        // Getter for the score
        public int GetScore()
        {
            return _score;
        }

        // Increment the score
        public void IncrementScore()
        {
            _score++;
            UpdateScoreText();
            Debug.Log("Score Incremented! Current Score: " + _score);
        }

        // Decrement the score
        public void DecrementScore()
        {
        
            // The score can't go under 0
            if (_score > 0)
            {
                _score--;
                UpdateScoreText();
                Debug.Log("Score Decremented! Current Score: " + _score);
            }
        
        }

        // Update the score text in the UI
        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = "Doel: Vind en sorteer afval (" + _score + "/10)";
            }

            if (_score >= 10)
            {
                scoreText.text = "Doel: Ga naar de portaal steen en verlaat deze wereld";
            }
        }

        public void InfoMessage(int status)
        {
            if (status ==  1)
                message.text = "Goed bezig!";
            else if (status == 2)
                message.text = "Dit afvalitem moet in een andere vuilbak";
            else if (status == 0)
                message.text = "";
        }
    
    }
}