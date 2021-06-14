using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class HandCurrent : MonoBehaviour
{
    [SerializeField] bool mbShowController = false;
    [SerializeField] List<GameObject> mlControllerPrefabs;
    [SerializeField] InputDeviceCharacteristics mInputDeviceCharacteristics;
    [SerializeField] GameObject mHandModelObjectPrefab;

    private InputDevice mTargetDevice;

    private GameObject mSpawnController;
    private GameObject mSpawnHand;
    private Animator mHandAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Init()
    {
        List<InputDevice> lDevices = new List<InputDevice>();
        //InputDevices.GetDevices(lDevices);
        InputDevices.GetDevicesWithCharacteristics(mInputDeviceCharacteristics, lDevices);

        foreach (var lItem in lDevices)
        {
            Debug.Log(lItem.name + " -- " + lItem.characteristics);
        }

        if (lDevices.Count > 0)
        {
            mTargetDevice = lDevices[0];

            Debug.Log("mTargetDevice: " + mTargetDevice.name);
            GameObject lPrefab = mlControllerPrefabs.Find(c => c.name.Contains(mTargetDevice.name));

            if (lPrefab)
                mSpawnController = Instantiate(lPrefab, transform);
            else
            {
                Debug.Log("No hemos encontrado el contralor");
                mSpawnController = Instantiate(mlControllerPrefabs[0], transform);
            }

            mSpawnHand = Instantiate(mHandModelObjectPrefab, transform);
            mHandAnimator = mSpawnHand.GetComponent<Animator>();
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (!mTargetDevice.isValid)
        {
            Init();
            return;
        }

        //mTargetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool lTriggerButtonValue);

        //if (lTriggerButtonValue)
        //    Debug.Log("lTriggerButtonValue presionado");

        if (mbShowController)
        {
            mSpawnHand.SetActive(false);
            mSpawnController.SetActive(true);
        }
        else
        {
            mSpawnHand.SetActive(true);
            mSpawnController.SetActive(false);
            UpdateAnim();
        }

    }

    void UpdateAnim()
    {
        if (mTargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float lTriggerValue))
            mHandAnimator.SetFloat("Trigger", lTriggerValue);
        else
            mHandAnimator.SetFloat("Trigger", 0);

        if (mTargetDevice.TryGetFeatureValue(CommonUsages.grip, out float lGripValue))
            mHandAnimator.SetFloat("Grip", lGripValue);
        else
            mHandAnimator.SetFloat("Grip", 0);


    }
}
