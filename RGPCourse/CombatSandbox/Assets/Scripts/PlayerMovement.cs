using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    bool isInDirectMode = false;
    [SerializeField] float walkMoveStopRadius = 0.2f;
    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentClickTarget;
    bool m_Jump=false;
        
    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }
    private void Update()
    {
        if (!m_Jump)
        {
            m_Jump = Input.GetButtonDown("Jump");
        }

    }
    // Fixed update is called in sync with physics

    private void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
            isInDirectMode = !isInDirectMode;
        if (isInDirectMode)
            ProcessDirectMovement();
        else
            ProcessIndirectMovement();
    }
    private void ProcessDirectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       // print(h + v);


        // calculate camera relative direction to move:
        Vector3 m_CamForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 m_Move = v * m_CamForward + h * Camera.main.transform.right;

        m_Character.Move(m_Move, false, m_Jump);
        m_Jump = false;


    }
    private void ProcessIndirectMovement()
    {
        if (Input.GetMouseButton(0))
        {
            print("Cursor raycast hit" + cameraRaycaster.hit.collider.gameObject.name.ToString());
            switch (cameraRaycaster.layerHit)
            {
                case Layer.Walkable:
                    currentClickTarget = cameraRaycaster.hit.point;
                    break;
                case Layer.Enemy:
                    print("Not moving to enemy");
                    break;
                default:
                    return;
                    print("Unexpected Layer Found");
            }
        }
        var playerToClickPoint = transform.position - currentClickTarget;
        if (playerToClickPoint.magnitude >= walkMoveStopRadius)
        {
            m_Character.Move(currentClickTarget - transform.position, false, m_Jump);           
        }
        else
        {
            m_Character.Move(Vector3.zero, false, m_Jump);
        }
        m_Jump = false;

    }
}

