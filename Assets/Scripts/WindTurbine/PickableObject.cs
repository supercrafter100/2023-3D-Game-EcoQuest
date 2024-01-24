using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{

    private Rigidbody objectRigidbody;
    private Collider _collider;
    private Transform objectPickupPointTransform;
    private ParticleSystem ps;
    // Start is called before the first frame update
    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
        _collider = GetComponent<Collider>();
    }

    public void Grab(Transform objectPickupPointTransform)
    {
        PlayerPrefs.SetInt("WindTurbine/holdingItem", 1);
        ps.Stop();
        this.objectPickupPointTransform = objectPickupPointTransform;
        objectRigidbody.useGravity = false;
        objectRigidbody.isKinematic = true;
        _collider.enabled = false;
    }

    public void Drop()
    {
        PlayerPrefs.SetInt("WindTurbine/holdingItem", 0);
        ps.Play();
        this.objectPickupPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;
        _collider.enabled = true;
    }

    private void FixedUpdate()
    {
        if (objectPickupPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectPickupPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }

}   
