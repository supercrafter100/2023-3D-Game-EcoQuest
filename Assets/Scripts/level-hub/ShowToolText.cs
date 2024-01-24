using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowToolText : MonoBehaviour
{

    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        textObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        textObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        textObject.SetActive(false);
    }
}
