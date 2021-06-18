using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class FollowPlayerNavMesh : MonoBehaviour
{
    [SerializeField] Transform mTarget;
    NavMeshAgent mAgent;

    // Start is called before the first frame update
    void Start()
    {
        if (mTarget == null)
            mTarget = GameObject.FindGameObjectWithTag("Player").transform;

        mAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        mAgent.destination = mTarget.position;
    }
}
