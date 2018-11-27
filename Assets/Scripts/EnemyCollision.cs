using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
    [SerializeField] int hitpoints = 5;
    [SerializeField] Collider collisonMesh;
    private void OnParticleCollision(GameObject other)
    {
        if (hitpoints <= 0)
        {
            KillEnemy();
        }
        else
        {
            hitpoints--;
            print(hitpoints);
        }

    }

    private void KillEnemy()
    {
        //deathSound.Play();
        //GameObject Fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        //Fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
