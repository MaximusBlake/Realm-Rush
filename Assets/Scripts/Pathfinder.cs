using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid= new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };
    
    void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbors();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            var searchCenter= queue.Dequeue();
            print("Searching from: "+ searchCenter); //todo remove log
            HaltIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
            searchCenter.isExplored = true;
        }
        print("Finished Pathfinding");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node therefore stopping"); //todo remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbors(Waypoint from)
    {
        if (!isRunning) { return;}
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                //do nothing
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        
        if (neighbor.isExplored)
        {
            //do nothing
        }
        else
        {
            neighbor.SetTopColor(Color.blue); //todo move later
            queue.Enqueue(neighbor);
            print("queuing " + neighbor);
        }
        
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.cyan);
        endWaypoint.SetTopColor(Color.magenta);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos= waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping Overlapping Block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
            
        }
    }
}
