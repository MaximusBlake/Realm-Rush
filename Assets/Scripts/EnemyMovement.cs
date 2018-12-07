using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementperiod = .5f;

    [SerializeField] ParticleSystem deathParticle;


    void Start () {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    IEnumerator FollowPath(List<Waypoint> path) //add smooth movement eventually
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementperiod);
        }
        KillEnemy();
    }
    private void KillEnemy()
    {
        //play a sound when enemy dies
        Vector3 deathPos = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
        var death = Instantiate(deathParticle, deathPos, Quaternion.identity);

        death.Play();
        float destroyDelay = death.main.duration;
        Destroy(death.gameObject, destroyDelay);

        Destroy(gameObject);
    }
}
