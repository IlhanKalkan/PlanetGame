using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static CameraManager instance;

    public Transform focus;
    public Vector3 distance;
    public Vector3 rotation;

    private Vector3 _distance;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _distance = distance;
    }

    private void LateUpdate()
    {
        var f = Input.GetAxis("Mouse ScrollWheel");
        if (f > 0)
        {
            // do not allow camera to zoom in more than this
            if (_distance.y > 1)
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
    }

    public void changeFocus(Transform t)
    {
        focus = t;
        Quaternion q = Quaternion.Euler(rotation);
        transform.rotation.Set(q.x, q.y, q.z, q.w);
    }
}
