using System;
using System.Collections;
using System.Collections.Generic;
using treePlanter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubTeleporter : MonoBehaviour
{
    public string scene;
    public GameManager game;
    public ParticleSystem particles;
    
    // Start is called before the first frame update
    void Start()
    {
        particles.Stop();     
    }

    // Update is called once per frame
    void Update()
    {
        if (game.isFinished && !particles.isPlaying) particles.Play(); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && game.isFinished)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
