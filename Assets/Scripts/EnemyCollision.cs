using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
    [SerializeField] int hitpoints = 15;

    [SerializeField] Collider collisonMesh;

    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;

    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitpoints <= 0)
        {
            KillEnemy();
            
        }

    }

    void ProcessHit()
    {
        hitpoints--;
        hitParticle.Play();
        myAudioSource.PlayOneShot(hitSFX);
    }

    private void KillEnemy()
    {
        Vector3 deathPos= new Vector3(transform.position.x, transform.position.y +20, transform.position.z);
        var deathParticles = Instantiate(deathParticle, deathPos, Quaternion.identity);

        deathParticles.Play();
        
        float destroyDelay= deathParticles.main.duration;
        Destroy(deathParticles.gameObject, destroyDelay);
        
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);

        Destroy(gameObject);
        print("Not Destroyed");
    }
}
