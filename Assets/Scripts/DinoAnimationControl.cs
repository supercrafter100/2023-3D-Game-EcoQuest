using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAnimation : MonoBehaviour
{

    public string dinoAnimtion;
    public bool isDanger;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.Play(dinoAnimtion);
        }


    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDanger)
        {
            animator.Play("TailAttack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isDanger)
        {
            animator.Play("Sleep");
        }
    }
}
