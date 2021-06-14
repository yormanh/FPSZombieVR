using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;

public class HandCurrent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Init()
    {
        List<InputDevice> lDevices = new List<InputDevice>();
        InputDevices.GetDevices(lDevices);

        foreach (var lItem in lDevices)
        {
            Debug.Log(lItem.name + " -- " + lItem.characteristics);
        }

    }


    // Update is called once per frame
    void Update()
    {
        Init();
    }
}
