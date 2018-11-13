using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    [SerializeField] Color exploredColor = Color.blue;

    public bool isExplored = false; // public ok cause data class
    public Waypoint exploredFrom;

    Vector2Int gridPos;
    const int gridSize = 10;
    private void Update()
    {
        /*if (isExplored)
        {
            SetTopColor(exploredColor);
        }*/
    }

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
    public void SetTopColor(Color color)
    {
        MeshRenderer topMesh= transform.Find("Top").GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }
}
