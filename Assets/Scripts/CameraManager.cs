using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public static CameraManager instance;

    public Transform focus;
    public Vector3 distance;
    public Vector3 rotation;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (focus != null)
        {
            transform.position = focus.position + distance;
        }
    }

    public void changeFocus(Transform t)
    {
        focus = t;
        Quaternion q = Quaternion.Euler(rotation);
        transform.rotation.Set(q.x, q.y, q.z, q.w);
    }
}
