using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraPan : MonoBehaviour
{
    Camera cameraMain;
    float minValMoveX, maxValMoveX;
    float minValMoveY, maxValMoveY;
    Vector3 moveBeginPos;
    public CameraData Data { get; private set; }

    void Awake()
    {
        cameraMain = GetComponent<Camera>();
        cameraMain.orthographicSize = 5;
        cameraMain.transform.position = new Vector3(0, 0, cameraMain.transform.position.z);
        Data = new CameraData();
        GameData.CameraPan.Set(this);
    }

    void Start()
    {
        UpdatePanBorder();
    }

    void Update()
    {
        if (Data.IsPan)
        {
            Pan();
            Zoom(Input.GetAxis("Mouse ScrollWheel") * Data.speedZoom);
            ClampPan();
        }
    }

    void Pan()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveBeginPos = cameraMain.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            transform.position += moveBeginPos - cameraMain.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void ClampPan()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minValMoveX, maxValMoveX),
            Mathf.Clamp(transform.position.y, maxValMoveY, minValMoveY), transform.position.z);
    }

    void Zoom(float delta)
    {
        if (delta == 0)
            return;
        cameraMain.orthographicSize = Mathf.Clamp(cameraMain.orthographicSize - delta, Data.zoomMin, Data.zoomMax);
        UpdatePanBorder();
    }

    void UpdatePanBorder()
    {
        GameData.Map.Get(out Map map);
        minValMoveX = Vector3.Distance(transform.position, cameraMain.ScreenToWorldPoint(new Vector3(0, Screen.height / 2)));
        minValMoveY = cameraMain.orthographicSize * -1;
        maxValMoveX = map.Data.Width - minValMoveX;
        maxValMoveY = (map.Data.Height + minValMoveY) * -1;
    }

}
