using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "Interactables/Orbiter/Planet")]
public class Planet : Orbiter
{

    [Header("Orbits")]
    public List<Moon> moons;
    public List<float> Xorbits;
    public List<float> Yorbits;

    private void Start()
    {
        moons = new List<Moon>();
    }

    public override void Click()
    {
        base.Click();
        // add planet-only code
    }
}