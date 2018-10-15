using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Sun", menuName = "Interactables/Sun")]
public class Sun : Interactable {

    public Vector3 position;
    public Vector3 Size;
   
    [Header("Orbits")]
    public List<Planet> planets;
    public List<float> Xorbits;
    public List<float> Yorbits;

    // rotating the orbiter
    [Header("Rotation")]
    [Range(0, 1)]
    public float xRotation;
    [Range(0, 1)]
    public float yRotation;
    [Range(0, 1)]
    public float zRotation;

    public float selfRotateSpeed;

    void Start () {
        planets = new List<Planet>();
	}

    public override void Click()
    {
        base.Click();
        // add planet-only code
    }
}
