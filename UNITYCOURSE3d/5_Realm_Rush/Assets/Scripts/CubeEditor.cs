
// The PrintAwake script is placed on a GameObject.  The Awake function is
// called when the GameObject is started at runtime.  The script is also
// called by the Editor.  An example is when the scene is changed to a
// different scene in the Project window.
// The Update() function is called, for example, when the GameObject transform
// position is changed in the Editor.

using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapTpGrid();
        UpdateLabel();
    }

    private void SnapTpGrid()
    {
        int gridSize = waypoint.GetGridSize();
        
        transform.position = new Vector3
            (waypoint.GetGridPos().x * gridSize,
            transform.position.y,
            waypoint.GetGridPos().y* gridSize);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
         textMesh.text = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        gameObject.name = labelText;
    }
}