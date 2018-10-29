using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class CubeEditorSnap : MonoBehaviour {

    [SerializeField] [Range(1f,20f)] float gridSize = 10f;

    TextMesh mesh;
    
    private void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        mesh = GetComponentInChildren<TextMesh>();
        string labelText= snapPos.x / gridSize + "," + snapPos.z / gridSize;
        mesh.text = labelText;
        gameObject.name = labelText;
    }
}
