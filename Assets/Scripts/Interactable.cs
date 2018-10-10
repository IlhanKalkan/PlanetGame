using UnityEngine;

[CreateAssetMenu(fileName = "New Interactable", menuName = "Interactables/Interactable")]
public class Interactable : ScriptableObject
{
    public new string name = "New Interactable";
    public Material material = null;

    public virtual void Click()
    {
        // interact
        // something might happen
        Debug.Log("Clicked " + name);
    }
}