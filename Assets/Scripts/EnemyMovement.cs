using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float movementperiod = .5f;
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
    }
}
