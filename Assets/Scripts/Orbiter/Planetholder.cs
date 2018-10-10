using System.Collections.Generic;
using UnityEngine;

public class Planetholder : OrbiterHolder {

    public Planet planet;
    
    private List<GameObject> goMoons = new List<GameObject>();
    private GameManager gameManager;

    public override void Initialize()
    {
        GetComponent<Renderer>().material = planet.material; // set material to planet's material
        rotation = new Vector3(planet.xRotation, planet.yRotation, planet.zRotation);
        selfRotateSpeed = planet.selfRotateSpeed;
        transform.localScale = planet.Size;
        Debug.Log("planet: " + planet.name.ToString());

        followthis = transform.parent.parent.GetComponentInChildren<SunHolder>().transform;
        Debug.Log("found papa: " + followthis.ToString());

        xAxis = planet.xAxis;
        yAxis = planet.yAxis;
        orbitProgress = planet.orbitProgress;
        orbitPeriod = planet.orbitPeriod;

        ellipse = new Ellipse(xAxis, yAxis);
    }
    
    private void Start()
    {
        gameManager = GameManager.instance;
        foreach(Moon moon in planet.moons)
        {
            goMoons.Add(gameManager.instantiate(this.transform, moon));
        }
    }   

    private void Update()
    {
        CalculateOrbit();
        Rotate();
    }
}
