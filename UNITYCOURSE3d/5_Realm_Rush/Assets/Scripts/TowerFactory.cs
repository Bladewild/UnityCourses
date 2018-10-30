using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();
    int numTowers = 0;


    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Vector3 newTransform = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y - 4.67f, baseWaypoint.transform.position.z);
        var newTower= Instantiate(towerPrefab, newTransform, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;

        towerQueue.Enqueue(newTower);
        //put new tower on the quej
    }

    private void MoveExistingTower(Waypoint newbaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        newbaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newbaseWaypoint;

        Vector3 newTransform = new Vector3(newbaseWaypoint.transform.position.x, newbaseWaypoint.transform.position.y - 4.67f, newbaseWaypoint.transform.position.z);
        oldTower.transform.position = newTransform;




        towerQueue.Enqueue(oldTower);

        //set placable flgas
        Debug.Log("Max Towers Reached");
    }
}
