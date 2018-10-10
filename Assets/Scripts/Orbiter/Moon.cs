using UnityEngine;

[CreateAssetMenu(fileName = "New Moon", menuName = "Interactables/Orbiter/Moon")]
public class Moon : Orbiter {

    public override void Click()
    {
        base.Click();
        // add planet-only code
    }
}
