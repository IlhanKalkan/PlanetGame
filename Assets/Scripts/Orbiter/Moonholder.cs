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
        Debug.Log("found papa: " + followthis.ToString());

        xAxis = moon.xAxis;
        yAxis = moon.yAxis;
        orbitProgress = moon.orbitProgress;
        orbitPeriod = moon.orbitPeriod;

        ellipse = new Ellipse(xAxis, yAxis);
    }

    private void Update()
    {
        CalculateOrbit();
        Rotate();
    }
}
