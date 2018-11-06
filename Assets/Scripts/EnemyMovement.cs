using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;
	void Start () {
        StartCoroutine(FollowPath());
    }
    IEnumerator FollowPath()
    {
        print("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting- "+waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending Patrol");
    }
}
