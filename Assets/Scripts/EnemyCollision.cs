using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
    [SerializeField] int hitpoints = 5;
    [SerializeField] Collider collisonMesh;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitpoints <= 0)
        {
            KillEnemy();
            
        }

    }

    private void ProcessHit()
    {
        hitpoints--;
        hitParticle.Play();
    }

    private void KillEnemy()
    {
        //play a sound when enemy dies
        Vector3 deathPos= new Vector3(transform.position.x, transform.position.y +20, transform.position.z);
        var death = Instantiate(deathParticle, deathPos, Quaternion.identity);

        death.Play();
        float destroyDelay= death.main.duration;
        Destroy(death.gameObject, destroyDelay);

        Destroy(gameObject);
    }
}
