using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHub : MonoBehaviour
{
    public bool LevelCompleted { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (LevelCompleted && Input.GetKeyDown(KeyCode.F))
            SceneManager.LoadScene("Level-hub");
    }




}
