using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [Header("Optional")][SerializeField] Transform PlayerPosition;
    GameObject player;
    [SerializeField] float smoothSpeed=0.05f;
	// Use this for initialization
	void Start () {
        if (!PlayerPosition)
            player= GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 newPlayerPosition;
        if (PlayerPosition)
            newPlayerPosition = PlayerPosition.position;
        else
            newPlayerPosition = player.transform.position;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPlayerPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
