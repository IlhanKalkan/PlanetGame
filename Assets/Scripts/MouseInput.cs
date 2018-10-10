using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

    public float rayLength = 100f;
    public LayerMask layermask;
    public Camera cam;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
	}

    void Click()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, rayLength, layermask))
        {
            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        } else
        {
            Debug.Log("Mouse btn pressed! Nothing found..");
        }
    }
}
