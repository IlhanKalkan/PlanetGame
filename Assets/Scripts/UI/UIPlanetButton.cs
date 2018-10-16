using UnityEngine;

public class UIPlanetButton : MonoBehaviour {

    public GameObject planetGameObject;

    public void OnClick()
    {
        Debug.Log("onclick called from UI: " + planetGameObject.name);
        CameraManager.instance.changeFocus(planetGameObject.transform.GetChild(0));
    }
	
}
