using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class HandCurrent : MonoBehaviour
{
    [SerializeField] List<GameObject> mlControllerPrefabs;
    [SerializeField] InputDeviceCharacteristics mInputDeviceCharacteristics;

    private InputDevice mTargetDevice;

    private GameObject mSpawnController;

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

        mTargetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool lTriggerButtonValue);

        if (lTriggerButtonValue)
            Debug.Log("lTriggerButtonValue presionado");

    }
}
