using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace trashSorting
{
    public class SceneSwitcher : MonoBehaviour
    {
        private PlayerInteraction _player;
        private GameManager _gameManager;
        private void Start()
        {
            _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            _player = GameObject.FindWithTag("Player").GetComponent<PlayerInteraction>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(_gameManager);
            Debug.Log(_player);
            if (_gameManager.GetScore() >= 10)
            {
                _player.interactionText.text = "Druk op F om terug naar de HUB te gaan";
                Debug.Log(_gameManager.GetScore());
                
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("GA NAAR HUB!!!");
                // TODO: uncomment onderstaande lijn en vul de correcte sceneNr. in (die van de hub)
                // SceneManager.LoadScene();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _player.interactionText.text = "";
        }
    }
}
