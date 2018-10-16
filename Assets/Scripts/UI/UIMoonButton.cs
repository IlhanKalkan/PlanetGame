using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoonButton : MonoBehaviour {

    public GameObject moonGameObject;

    public void OnClick()
    {
        var script = moonGameObject.transform.GetChild(0).GetComponent<Moonholder>();
        // Call the main script onclick
        script.OnClick();
    }
}
