using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class cameraScaling : MonoBehaviour
{
    public float sceneWidth = 36;
    Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        _camera.orthographicSize = desiredHalfHeight;
    }
}
