using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetCrosshairText : MonoBehaviour
{
    [SerializeField] private TMP_Text crosshairHotkey;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickupLayerMask;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("WindTurbine/holdingItem", 0);
    }
        // Update is called once per frame
        void Update()
    {

        if (PlayerPrefs.GetInt("WindTurbine/holdingItem") == 0)
        {
            float pickUpDistance = 8f;
            if (Physics.SphereCast(playerCameraTransform.position, 0.3f, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickupLayerMask))
            {
                SetText("Druk op F om de wiek op te rapen");
            }
            else
            {
                SetText("");
            }

        }
        else
        {
            SetText("Druk op F om de wiek te laten vallen");
        }


    }

    public void SetText(string s)
    {
        crosshairHotkey.SetText(s);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("WindTurbine/holdingItem", 0); 
    }
}
