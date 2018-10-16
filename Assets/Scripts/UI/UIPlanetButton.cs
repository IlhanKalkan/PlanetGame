using System.Collections.Generic;
using UnityEngine;

public class UIPlanetButton : MonoBehaviour {

    public GameObject planetGameObject;

    public void OnClick()
    {
        var script = planetGameObject.transform.GetChild(0).GetComponent<Planetholder>();
        script.OnClick();
    }
	
}
