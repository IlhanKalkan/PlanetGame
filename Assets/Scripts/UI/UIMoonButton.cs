using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoonButton : MonoBehaviour {

    public GameObject moonGameObject;

    public void OnClick()
    {
        var script = moonGameObject.transform.GetChild(0).GetComponent<Moonholder>();
        Vector3 ms = script.moon.Size;
        var size = Mathf.Max(Mathf.Max(ms.x, ms.y), ms.z);
        CameraManager.instance.changeFocus(moonGameObject.transform.GetChild(0), size);
        Debug.Log("onclick called from UI: " + moonGameObject.name + ".. size found: " + size);
    }
}
