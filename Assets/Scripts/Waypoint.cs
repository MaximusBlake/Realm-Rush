using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    [SerializeField] Tower towerPrefab;

    public bool isExplored = false; // public ok cause it's data class
    public Waypoint exploredFrom;
    public bool isPlacable= true;

    Vector2Int gridPos;
    const int gridSize = 10;

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
        
    }
    public int GetGridSize()
    {
        return gridSize;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                Vector3 towerPos = new Vector3(transform.position.x, transform.position.y+10, transform.position.z );
                Instantiate(towerPrefab, towerPos, Quaternion.identity);
                isPlacable = false;
            }
            else
            {
                print("Can't Place Tower Here");
            }
            
        }
    }
}
