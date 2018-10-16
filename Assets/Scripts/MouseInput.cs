using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour {

    public float rayLength = 100f;
    public LayerMask layermask;
    public Camera cam;
    private UIManager ui;

    private void Start()
    {
        ui = UIManager.instance;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
	}

    void Click()
    {
        //The method returns true if our mouse is hovering over UI. We only want to cast our rays if we do not click on ui.
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layermask))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                if (hit.transform.GetComponent<Planetholder>() != null)
                {
                    Planetholder planetH = hit.transform.GetComponent<Planetholder>();
                    planetH.OnClick();
                }
                else if (hit.transform.GetComponent<Moonholder>() != null)
                {
                    Moonholder moonH = hit.transform.GetComponent<Moonholder>();
                    moonH.OnClick();
                }
            }
            else
            {
                ui.HidePopup();
            }
        }

    }
}
