using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVisible()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = true;
    }

    public void SetInvisible()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = false;
    }
}
