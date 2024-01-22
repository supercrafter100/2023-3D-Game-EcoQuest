using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWings : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private int counter = 0;
    private ToggleRenderer[] renderers;

    private void Awake()
    {
        renderers = GetComponentsInChildren<ToggleRenderer>();
        foreach (ToggleRenderer r in renderers)
        {
            r.SetInvisible();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (counter >= 3)
        {
            return;
        }
        if (other.CompareTag("PickableObject"))
        {
            Debug.Log("PickableObject collided");
            Destroy(other.gameObject);
            
            renderers[counter].SetVisible();
            counter++;
        }
        if(counter >= 3)
        {
            animator.SetTrigger("AllWingsCollected");
        }
    }
}
