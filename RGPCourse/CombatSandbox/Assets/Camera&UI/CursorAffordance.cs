using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D targetCursor = null;
    [SerializeField] Texture2D unkownCursor = null;
    [SerializeField] Vector2 cursourHotspot = new Vector2(96, 96);
    CameraRaycaster cameraRaycaster;

    // Use this for initialization
    void Start () {
        cameraRaycaster = GetComponent<CameraRaycaster>();
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        switch (cameraRaycaster.layerHit)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursourHotspot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(targetCursor, cursourHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(unkownCursor, cursourHotspot, CursorMode.Auto);
                break;
            default:
                Debug.LogError("Uknown cursor...");
                break;
        }
		
	}
}
