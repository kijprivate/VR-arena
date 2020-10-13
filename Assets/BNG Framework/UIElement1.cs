//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: UIElement that responds to VR hands and generates UnityEvents
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using BNG;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class UIElement1 : MonoBehaviour
{
    [SerializeField] SteamVR_Action_Boolean testction;
    protected Grabber currentHand;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Grabber>())
        {
            Debug.LogError("Trigger grabber");
            currentHand = other.GetComponent<Grabber>();

            ControllerButtonHints.ShowButtonHint(currentHand, testction);
        }
    }
}
