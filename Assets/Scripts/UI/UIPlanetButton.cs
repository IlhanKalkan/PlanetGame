using System.Collections.Generic;
using UnityEngine;

public class UIPlanetButton : MonoBehaviour {

    public GameObject planetGameObject;

    public void OnClick()
    {
        var script = planetGameObject.transform.GetChild(0).GetComponent<Planetholder>();
        Vector3 ps = script.planet.Size;
        var size = Mathf.Max(Mathf.Max(ps.x, ps.y), ps.z);
        CameraManager.instance.changeFocus(planetGameObject.transform.GetChild(0), size);
        //Debug.Log("onclick called from UI: " + planetGameObject.name + ".. size found: " + size);

        // Change the moon view
        UIManager ui = UIManager.instance;
        ui.ClearMoonBtns();
        List<GameObject> goMoons = script.goMoons;
        foreach(GameObject g in goMoons)
        {
            ui.AddMoonBtn(g);
        }
    }
	
}
