using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditorSnap : MonoBehaviour {
    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x, //x
            0f,//y
            waypoint.GetGridPos().y);//z
    }
    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        TextMesh mesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            waypoint.GetGridPos().x / gridSize + 
            "," + 
            waypoint.GetGridPos().y / gridSize;
        mesh.text = labelText;
        gameObject.name = labelText;
    }

}
