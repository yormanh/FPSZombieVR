using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class TeleportController : MonoBehaviour
{
    [SerializeField] XRBaseController mLeftTeleportController;
    [SerializeField] XRBaseController mRightTeleportController;

    [SerializeField] InputActionAsset mActionAsset;
    [SerializeField] TeleportationProvider mTeleportationProvider;

    // Start is called before the first frame update
    void Start()
    {
        var lActivateLeftHand = mActionAsset.FindActionMap("XRI LeftHand").FindAction("Activate");
        lActivateLeftHand.Enable();
        lActivateLeftHand.performed += OnTeleportActivateLeftHand;
        
        var lCancelLeftHand = mActionAsset.FindActionMap("XRI LeftHand").FindAction("Activate");
        lCancelLeftHand.Enable();
        lActivateLeftHand.canceled += OnTeleportCancelLeftHand;

    }

    private void OnTeleportActivateLeftHand(InputAction.CallbackContext context)
    {
        Debug.Log("OnTeleportActivateLeftHand" + context.performed);
    }

    private void OnTeleportCancelLeftHand(InputAction.CallbackContext context)
    {
        Debug.Log("OnTeleportCancelLeftHand" + context.performed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
