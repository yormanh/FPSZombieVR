using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZombie : MonoBehaviour
{
    Transform mPlayer;
    Animator mAnimator;
    DamageableCharacter mDamageableCharacter;

    [SerializeField] float mfDistanceAttack = 2.5f;
    [SerializeField] float mfDIstanceChase = 100f;
    [SerializeField] int miDamage = 10;
    [SerializeField] float mfAttackTime = 1.0f;

    private bool mbIsDead = false;

    FollowPlayerNavMesh mFollowPlayerNavMesh;
    public bool mbCanAttack = true;


    // Start is called before the first frame update
    void Start()
    {
        mPlayer = GameObject.FindWithTag("Player").transform;
        mAnimator = GetComponent<Animator>();
        mDamageableCharacter = GetComponent<DamageableCharacter>();
        mFollowPlayerNavMesh = GetComponent<FollowPlayerNavMesh>();

        //mFollowPlayerNavMesh.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mDamageableCharacter.GetIsDead())
        {
            float lfDistanceToPlayer = Vector3.Distance(transform.position, mPlayer.position);

            if (lfDistanceToPlayer < mfDIstanceChase)
            {
                if (lfDistanceToPlayer > mfDistanceAttack)
                    Chase();
                else if (mbCanAttack)
                    Attack();
            }
        }

        if (mDamageableCharacter.GetIsDead() && !mbIsDead)
            Die();

    }


    public void Die()
    {
        mAnimator.SetTrigger("IsDead");
        mbIsDead = true;
    }


    void Chase()
    {
        mAnimator.SetBool("IsWalking", true);
        mAnimator.SetBool("IsAttacking", false);
    }


    void Attack()
    {
        mAnimator.SetBool("IsWalking", false);
        mAnimator.SetBool("IsAttacking", true);


        StartCoroutine("AttackTime");
    }

    IEnumerator AttackTime()
    {
        mbCanAttack = false;
        Debug.Log("Atacnado al playe r");
        yield return new WaitForSeconds(mfAttackTime);
        mbCanAttack = true;

    }


}
