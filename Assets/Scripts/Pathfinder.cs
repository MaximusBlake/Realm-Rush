using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid= new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    Waypoint searchCenter;

    List<Waypoint> path= new List<Waypoint>(); //make private

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };
    
    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        Waypoint previous = endWaypoint.exploredFrom;
        path.Add(previous);
        while (previous!= startWaypoint)
        {
            //add intermediate waypoints
            path.Add(endWaypoint);
            previous = endWaypoint.exploredFrom;
            path.Add(previous);
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning) 
        {
            searchCenter= queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node therefore stopping"); //todo remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbors()
    {
        if (!isRunning) { return;}
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
            
            if(grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor;
        
           
        neighbor = grid[neighborCoordinates];

        if (neighbor.isExplored || queue.Contains(neighbor))
        {
            //do nothing
        }
        else
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
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
