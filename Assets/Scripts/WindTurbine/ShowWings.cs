using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowWings : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text objectiveTracker;
    [SerializeField] private AudioSource audioSource;
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
        if (other is not MeshCollider) return;
        if (counter >= 3)
        {
            return;
        }
        if (other.CompareTag("PickableObject"))
        {
            Debug.Log("PickableObject collided");
            Destroy(other.gameObject.gameObject);
            
            renderers[counter].SetVisible();
            counter++;
            objectiveTracker.SetText(counter.ToString());
        }
        if(counter >= 3)
        {
            animator.SetTrigger("AllWingsCollected");
            audioSource.Play();
        }
    }
}
