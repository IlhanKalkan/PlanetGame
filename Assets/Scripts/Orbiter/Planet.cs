using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Planet", menuName = "Interactables/Orbiter/Planet")]
public class Planet : Orbiter
{
    public List<Moon> moons;

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