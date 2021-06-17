using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : BaseBullet
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, mfLifeTime);
    }



    public void OnTriggerEnter(Collider pOther)
    {
        if (pOther.CompareTag(msTargetTag))
        {
            pOther.GetComponent<DamageableCharacter>().TakeDamage(miDamage);
        }

        Destroy(this.gameObject);
    }

}
