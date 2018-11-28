using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    //Parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] ParticleSystem bulletParticles;
    [SerializeField] float attackRange =30;
    //State
    Transform targetEnemy;
    void Update () {
        SetTargetEnemy();
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
	}

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyCollision>();
        if (sceneEnemies.Length == 0) {return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyCollision testEnemy in sceneEnemies){
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform TransA, Transform TransB)
    {
        float distanceToA = Vector3.Distance(TransA.transform.position, gameObject.transform.position);
        float distanceToB = Vector3.Distance(TransB.transform.position, gameObject.transform.position);
        if (distanceToA > distanceToB)
        {
            return TransB;
        }
        else
        {
            return TransA;
        }
    }

    void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy<= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool shootOn)
    {
        var emissionModule = bulletParticles.emission;
        emissionModule.enabled = shootOn;
    }
}
