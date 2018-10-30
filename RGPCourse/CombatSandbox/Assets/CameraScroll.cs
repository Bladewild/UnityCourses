using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

    [SerializeField] Transform TargetRail;
    [SerializeField] Transform TargetCamera;
    [SerializeField] Transform ZoomedInPosition;
    [SerializeField] Transform ZoomedOutPosition;
    [SerializeField] float smoothRailPositionnSpeed = 0.1f;
    [SerializeField] float smoothRailRotationSpeed = 0.125f;
    [SerializeField] float railMultiplier = 1f;

    [SerializeField] float smoothtransformSpeed = 0.125f;
    [SerializeField] float smoothrotationSpeed =0.1f;
    [SerializeField] float cameraMultiplier = 1f;

    void Update()
    {
        RailMovement();
        CameraTrackRail();
    }

    private void RailMovement()
    {
        Vector3 desiredRailPosition;
        Quaternion desiredRailRotation;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            desiredRailPosition = ZoomedInPosition.position;
            desiredRailRotation = ZoomedInPosition.rotation;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            desiredRailPosition = ZoomedOutPosition.position;
            desiredRailRotation = ZoomedOutPosition.rotation;
        }
        else
        {
            desiredRailPosition = TargetRail.position;
            desiredRailRotation = TargetRail.rotation;
        }

        Vector3 smoothedPosition = Vector3.Lerp(TargetRail.position, desiredRailPosition, smoothRailPositionnSpeed* railMultiplier);
        TargetRail.position = smoothedPosition;
        
        Quaternion smoothRotation = Quaternion.Lerp(TargetRail.rotation, desiredRailRotation, smoothRailRotationSpeed* railMultiplier);
        TargetRail.rotation = smoothRotation;
        
    }
    
    private void CameraTrackRail()
    {
        Vector3 smoothedPosition = Vector3.Lerp(TargetCamera.position, TargetRail.position, smoothtransformSpeed* cameraMultiplier);
        TargetCamera.position = smoothedPosition;

        Quaternion smoothRotation = Quaternion.Lerp(TargetCamera.rotation, TargetRail.rotation, smoothrotationSpeed* cameraMultiplier);
        TargetCamera.rotation = smoothRotation;

    }

}

