﻿using UnityEngine;

public abstract class OrbiterHolder : MonoBehaviour {

    public float xAxis;
    public float yAxis;
    // for orbiting
    public bool orbitActive = true;
    public float orbitProgress;
    public float orbitPeriod;

    public Ellipse ellipse;


    // for rotating
    public Vector3 rotation;
    public float selfRotateSpeed;

    public abstract void Initialize();

    public void CalculateOrbit()
    {
        Vector2 orbitPos = ellipse.Evaluate(orbitProgress);
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        float orbitSpeed = 1f / orbitPeriod;

        if (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
        }

        Vector3 p = transform.parent.transform.position;
        transform.position = new Vector3(p.x + orbitPos.x,p.y + 0, p.z + orbitPos.y);
    }

    public void Rotate()
    {
        transform.Rotate(rotation * Time.deltaTime * selfRotateSpeed);
    }
}
