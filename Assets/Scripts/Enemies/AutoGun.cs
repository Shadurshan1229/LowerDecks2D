using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGun : MonoBehaviour
{

    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] lasers;

    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;

        lasers[FindLaser()].transform.position = firePoint.position;
        lasers[FindLaser()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindLaser()
    {
        for (int i = 0; i < lasers.Length; i++)
        {
            if (!lasers[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer>=attackCooldown)
        {
            Attack();
        }
    }
}
