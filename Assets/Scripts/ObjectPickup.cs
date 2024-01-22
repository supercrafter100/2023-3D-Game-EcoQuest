using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjectPickup : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectPickupPointTransform;
    [SerializeField] private LayerMask pickupLayerMask;


    private PickableObject pickableObject;
    // Start is called before the first frame update
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("F key pressed");
            float pickUpDistance = 8f;
            if (pickableObject == null)
            {
                if (Physics.SphereCast(playerCameraTransform.position, 0.3f, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out pickableObject))
                    {
                        pickableObject.Grab(objectPickupPointTransform);
                    }
                }
            } else
            {
                pickableObject.Drop();
                pickableObject = null;
            }
        }

    }

}
