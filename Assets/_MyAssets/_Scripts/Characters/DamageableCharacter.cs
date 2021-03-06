using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour
{
    [SerializeField] private int miMaxLife = 100;
    private int miCurrentLife;
    protected bool mbIsDead = false;

    public int GetCurrentLife ()
    {
        return miCurrentLife;
    }


    public void SetCurrentLife (int piValue)
    {
        miCurrentLife = Mathf.Clamp(miCurrentLife + piValue, 0, miMaxLife);
    }

    public int GetMaxLife()
    {
        return miMaxLife;
    }


    public bool GetIsDead()
    {
        return mbIsDead;
    }



    // Start is called before the first frame update
    void Start()
    {

        miCurrentLife = miMaxLife;
    }


    public void TakeDamage (int piDamage)
    {
        miCurrentLife -= piDamage;
        miCurrentLife = Mathf.Clamp(miCurrentLife, 0, miMaxLife);

        if (miCurrentLife == 0)
        {
            mbIsDead = true;
        }
        Debug.Log("Current Life: " + miCurrentLife);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
