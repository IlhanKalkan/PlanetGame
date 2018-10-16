using UnityEngine;

public class Moonholder : OrbiterHolder {

    public Moon moon;

    public override void Initialize()
    {
        GetComponent<Renderer>().material = moon.material; // set material to planet's material
        rotation = new Vector3(moon.xRotation, moon.yRotation, moon.zRotation);
        selfRotateSpeed = moon.selfRotateSpeed;
        transform.localScale = moon.Size;

        followthis = transform.parent.parent.GetComponentInChildren<Planetholder>().transform;
        //Debug.Log("found papa: " + followthis.ToString());

        orbitProgress = moon.orbitProgress;
        orbitPeriod = moon.orbitPeriod;

        ellipse = new Ellipse(xAxis, yAxis);
    }

    private void Update()
    {
        CalculateOrbit();
        Rotate();
    }

    public override void OnClick()
    {
        ui.ShowPopup(this);

        Vector3 ms = moon.Size;
        var size = Mathf.Max(Mathf.Max(ms.x, ms.y), ms.z);
        CameraManager.instance.changeFocus(transform, size);
    }
}
