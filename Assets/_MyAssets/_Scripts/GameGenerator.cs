using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    [Header("Magazine")]
    [SerializeField] GameObject mMagazinePrefab;
    [SerializeField] Transform mMagazineParent;
    [SerializeField] GameObject[] mMagazinePositions;


    [Header("Zombie")]
    [SerializeField] GameObject mZombiePrefab;
    [SerializeField] Transform mZombieParent;
    [SerializeField] GameObject[] mZombiePositions;


    [Header("General")]
    [SerializeField] float mfTimeBetweenWaves = 5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateWave", mfTimeBetweenWaves, mfTimeBetweenWaves);
    }


    void GenerateWave ()
    {
        int liNumber = Random.Range(0, mMagazinePositions.Length - 1);

        Instantiate(mMagazinePrefab, mMagazinePositions[liNumber].transform.position, Quaternion.identity, mMagazineParent);

        Instantiate(mZombiePrefab, mZombiePositions[liNumber].transform.position, Quaternion.identity, mZombieParent);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
