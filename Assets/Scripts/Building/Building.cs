using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Interactables/Building")]
public class Building : Interactable {

    public new string name = "New Building";
    public Recipe recipe;
}
