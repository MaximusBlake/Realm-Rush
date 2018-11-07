﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    Vector2Int gridPos;
    const int gridSize = 10;

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
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
