using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float ControlSpeed = 15f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5;

    [Header("Control-position Based")]
    [SerializeField] float controlRollactor = -20f;
    [SerializeField] float controlPitchFactor = -20f;
    float xThrow, yThrow;
    bool isControlEnabled = true;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }

    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Jump"))//Spacebar
            SetGunsActive(true);
        else
            SetGunsActive(false);
  
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns) //may effect death
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }


    void OnPlayerDeath() //called by string reference
    {
        print("Control's Frozen");
        isControlEnabled = false;
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float yOffset = yThrow * ControlSpeed * Time.deltaTime;
        float xOffset = xThrow * ControlSpeed * Time.deltaTime;

        float rawNewypos = transform.localPosition.y + yOffset;
        float rawNewXpos = transform.localPosition.x + xOffset;

        float clampedXpos = Mathf.Clamp(rawNewXpos, -xRange, xRange);
        float clampedypos = Mathf.Clamp(rawNewypos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXpos, clampedypos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float picthDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow *controlPitchFactor ;
        float pitch = picthDueToPosition + pitchDueToControl;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToControl = xThrow * controlRollactor;
        float roll = rollDueToControl;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
    }


}
