using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    const int gridSize = 10;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    public bool canColor= true;
    public bool isPlaceable = true;
    [SerializeField] Tower towerPrefab;

    [SerializeField] Color exploredColor= Color.black;
    // Use this for initialization
    void Start () {
		
	}
    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer= GetComponent<MeshRenderer>();
        topMeshRenderer.materials[1].color = color;
    }
    // Update is called once per frame
    void Update () {
        if(isExplored && canColor)
           SetTopColor(exploredColor);

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
    }
}
