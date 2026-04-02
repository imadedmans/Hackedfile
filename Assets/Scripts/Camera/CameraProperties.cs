using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraProperties : MonoBehaviour
{
    public static float screenX;
    public static float screenY;
    new Camera camera;

    void Awake()
    {
        camera = FindObjectOfType<Camera>();
        screenX = camera.orthographicSize * 2f * camera.aspect;
        screenY = camera.orthographicSize * 2f;
    }

    void Update()
    {
        screenX = camera.orthographicSize * 2f * camera.aspect;
        screenY = camera.orthographicSize * 2f;
    }
}
