using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVR : DamageableCharacter
{
    DamageableCharacter mDamageableCharacter;

    // Start is called before the first frame update
    void Start()
    {
        mDamageableCharacter = GetComponent<DamageableCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mDamageableCharacter.GetIsDead())
            Debug.Log("Player está muerto");
    }
}
