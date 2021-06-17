using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{

    [SerializeField] protected int miDamage = 50;
    [SerializeField] protected float mfLifeTime = 3f;
    [SerializeField] protected string msTargetTag = "Enemy";

    public int GetDamage()
    {
        return miDamage;
    }

    public void SetDamage(int piValue)
    {
        miDamage = piValue;
    }


}
