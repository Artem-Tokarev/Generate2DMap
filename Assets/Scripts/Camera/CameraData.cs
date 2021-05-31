using UnityEngine;

[System.Serializable]
public class CameraData
{
    [Range(3, 5)] public float zoomMin = 3;
    [Range(5, 7)] public float zoomMax = 7;
    [Range(1, 5)] public float speedZoom = 3;
    public bool IsPan { get; set; } = true;
}
