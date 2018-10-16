using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoonButton : MonoBehaviour {

    public GameObject moonGameObject;

    public void OnClick()
    {
        Debug.Log("onclick called from UI: " + moonGameObject.name);
        CameraManager.instance.changeFocus(moonGameObject.transform.GetChild(0));
    }
}
