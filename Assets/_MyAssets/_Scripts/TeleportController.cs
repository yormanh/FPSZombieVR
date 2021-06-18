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

    [SerializeField] XRRayInteractor mLeftRayInteractor;
    [SerializeField] XRRayInteractor mRightRayInteractor;


    public bool EnableLeftTeleport { get; set; } = true;
    public bool EnableRightTeleport { get; set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        var lActivateLeftHand = mActionAsset.FindActionMap("XRI LeftHand").FindAction("Activate");
        lActivateLeftHand.Enable();
        lActivateLeftHand.performed += OnTeleportActivateLeftHand;
        
        var lCancelLeftHand = mActionAsset.FindActionMap("XRI LeftHand").FindAction("Activate");
        lCancelLeftHand.Enable();
        lCancelLeftHand.canceled += OnTeleportCancelLeftHand;


        var lActivateRightHand = mActionAsset.FindActionMap("XRI RightHand").FindAction("Activate");
        lActivateRightHand.Enable();
        lActivateRightHand.performed += OnTeleportActivateRightHand;

        var lCancelRightHand = mActionAsset.FindActionMap("XRI RightHand").FindAction("Activate");
        lCancelRightHand.Enable();
        lCancelRightHand.canceled += OnTeleportCancelRightHand;


    }

    private void OnTeleportActivateLeftHand(InputAction.CallbackContext context)
    {
        //Debug.Log("OnTeleportActivateLeftHand" + context.performed);
        if (EnableLeftTeleport)
        {
            bool lbIsLefInteractorRayHover = mLeftRayInteractor.TryGetHitInfo(out Vector3 postition, out Vector3 normal, out int index, out bool isValidTarget);
            if (!lbIsLefInteractorRayHover)
                mLeftTeleportController.gameObject.GetComponent<XRRayInteractor>().enabled = true;
        }

    }

    private void OnTeleportCancelLeftHand(InputAction.CallbackContext context)
    {
        //Debug.Log("OnTeleportCancelLeftHand" + context.performed);
        TeleportMove(mLeftTeleportController);
        mLeftTeleportController.gameObject.GetComponent<XRRayInteractor>().enabled = false;
    }

    private void OnTeleportActivateRightHand(InputAction.CallbackContext context)
    {
        //Debug.Log("OnTeleportActivateRightHand" + context.performed);
        if (EnableRightTeleport)
        {
            bool lbIsRightInteractorRayHover = mRightRayInteractor.TryGetHitInfo(out Vector3 postition, out Vector3 normal, out int index, out bool isValidTarget);
            if (!lbIsRightInteractorRayHover)
                mRightTeleportController.gameObject.GetComponent<XRRayInteractor>().enabled = true;
        }
    }

    private void OnTeleportCancelRightHand(InputAction.CallbackContext context)
    {
        //Debug.Log("OnTeleportCancelRightHand" + context.performed);
        TeleportMove(mRightTeleportController);
        mRightTeleportController.gameObject.GetComponent<XRRayInteractor>().enabled = false;
    }




 


    private void TeleportMove(XRBaseController controller)
    {

        if (!controller.GetComponent<XRRayInteractor>().TryGetCurrent3DRaycastHit(out RaycastHit hit) || hit.transform.GetComponent<TeleportationArea>() == null)
        {
            controller.gameObject.GetComponent<XRRayInteractor>().enabled = false;
            return;
        }

        TeleportRequest lRequest = new TeleportRequest()
        {
            destinationPosition = hit.point
        };

        mTeleportationProvider.QueueTeleportRequest(lRequest);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
