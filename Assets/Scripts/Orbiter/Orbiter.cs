using UnityEngine;

public abstract class Orbiter : Interactable {

    // orbiter size
    public Vector3 Size; // We scale the sphere with x,y,z values of the size

    // orbit ellipse size
    public float xAxis;
    public float yAxis;
    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    [Range(1f, 100f)]
    public float orbitPeriod = 3f;

    // rotating the orbiter
    [Header("Rotation")]
    [Range(0, 1)]
    public float xRotation;
    [Range(0, 1)]
    public float yRotation;
    [Range(0, 1)]
    public float zRotation;

    public float selfRotateSpeed;

    // For holding buildings
    [Header("Buildings")]
    [Range(0, 10)]
    public int maxBuildings;
    public int currentBuildingAmt;
    public Building[] Buildings;
}
