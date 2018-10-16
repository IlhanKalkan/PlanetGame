using System.Collections.Generic;
using UnityEngine;

public class UIPlanetButton : MonoBehaviour {

    public GameObject planetGameObject;

    public void OnClick()
    {
        Debug.Log("onclick called from UI: " + planetGameObject.name);
        CameraManager.instance.changeFocus(planetGameObject.transform.GetChild(0));

        // Change the moon view
        UIManager ui = UIManager.instance;
        ui.ClearMoonBtns();
        List<GameObject> goMoons = planetGameObject.GetComponentInChildren<Planetholder>().goMoons;
        foreach(GameObject g in goMoons)
        {
            ui.AddMoonBtn(g);
        }
    }
	
}
