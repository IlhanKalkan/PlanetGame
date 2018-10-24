using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static CameraManager instance;

    [Header("Minimap")]
    public GameObject minimapHolder;
    public Camera minimapCam;
    public Vector3 minimapCamDist = new Vector3(0, 30, 0);

    [Header("Focus")]
    public Transform focus;
    public Vector3 distance;
    public Vector3 rotation;

    private Vector3 _distance;

    private float minimalPossibleZoom = 1;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _distance = distance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){
            ToggleMinimap();
        }
    }

    public void ToggleMinimap()
    {
        minimapHolder.SetActive(!minimapHolder.activeSelf);
    }

    private void LateUpdate()
    {
        var f = Input.GetAxis("Mouse ScrollWheel");
        if (f > 0)
        {
            // if camera distance is bigger than the max allowed zoom, we are allowed to zoom in.
            if (_distance.y > minimalPossibleZoom)
            {
                _distance *= 0.9f;
            }
        }
        else if (f < 0)
        {
            _distance *= 1.1f;
            _distance = Vector3.ClampMagnitude(_distance, 20);
        }

        //Debug.Log(Vector3.Distance(distance, _distance).ToString());

        if (focus != null)
        {
            transform.position = focus.position + _distance;
        }

        minimapCam.transform.position = focus.position + minimapCamDist;
    }

    public void changeFocus(Transform t, float size)
    {
        focus = t;
        Quaternion q = Quaternion.Euler(rotation);
        transform.rotation.Set(q.x, q.y, q.z, q.w);
        minimalPossibleZoom = size/2 + 0.5f;

        // Readjust cam pos
        if (_distance.y < minimalPossibleZoom)
        {
            _distance = new Vector3(0, minimalPossibleZoom, - minimalPossibleZoom / 12 * 16);
        }
    }
}
