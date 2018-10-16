using System.Collections.Generic;
using UnityEngine;

public class Planetholder : OrbiterHolder {

    public Planet planet;
    
    public List<GameObject> goMoons = new List<GameObject>();

    public override void Initialize()
    {
        GetComponent<Renderer>().material = planet.material; // set material to planet's material
        rotation = new Vector3(planet.xRotation, planet.yRotation, planet.zRotation);
        selfRotateSpeed = planet.selfRotateSpeed;
        transform.localScale = planet.Size;
        //Debug.Log("planet: " + planet.name.ToString());

        followthis = transform.parent.parent.GetComponentInChildren<SunHolder>().transform;
        //Debug.Log("found papa: " + followthis.ToString());

        orbitProgress = planet.orbitProgress;
        orbitPeriod = planet.orbitPeriod;

        ellipse = new Ellipse(xAxis, yAxis);
    }
    
    private void Start()
    {
        GameManager gameManager = GameManager.instance;
        UIManager ui = UIManager.instance;
        for (int i = 0; i < planet.moons.Count; i++)
        {
            //Debug.Log("found planet in sun.planets:" + p.name.ToString());
            Moon m = planet.moons[i];
            GameObject g = gameManager.instantiate(planet, transform, i, m);
            if (g != null)
            {
                goMoons.Add(g);
            }
        }
    }   

    private void Update()
    {
        CalculateOrbit();
        Rotate();
    }
}
