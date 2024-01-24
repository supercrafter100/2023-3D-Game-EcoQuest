using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecretDinos : MonoBehaviour
{

    public float rotationSpeed = 50f; // Snelheid van de rotatie

    public TMP_Text scoreboardText;

    private static int totalDinos = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreboardText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Rotatie om de Y-as
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            totalDinos++;

            scoreboardText.text = "Dino's verzameld: " + totalDinos + "/4";

            Destroy(gameObject);
        }
    }
}
