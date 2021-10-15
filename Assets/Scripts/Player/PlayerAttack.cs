using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Lasers;

    private Animator anim;
    private Player_Movement playerMovement;
    private float cooldownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Player_Movement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //Pool Lasers
        Lasers[FindLaser()].transform.position = firePoint.position;
        Lasers[FindLaser()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindLaser()
    {
        for(int i = 0; i < Lasers.Length; i++)
        {
            if (!Lasers[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
