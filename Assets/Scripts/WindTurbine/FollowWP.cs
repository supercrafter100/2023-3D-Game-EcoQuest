using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    private Animator animator;
    int currentWP = 0;

    public float speed = 10.0f;
    // Start is called before the first frame update
    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("State", 12);
        if (Vector3.Distance(transform.position, waypoints[currentWP].transform.position) <= 3)
        {
            currentWP++;
        }

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        transform.LookAt(waypoints[currentWP].transform);
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
